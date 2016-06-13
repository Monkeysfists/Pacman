using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace Pacman
{
    public abstract class SafeFileHandler
    {

        protected Dictionary<string, string> data;
        protected string grav, path;
        protected Random rand;

        public SafeFileHandler(string path, string GRAV = "", Dictionary<string, string> defaultData = null)
        {
            if(GRAV == null || GRAV == "")
                GRAV = path.Substring(path.LastIndexOf('.') + 1); // get GRAV from file extention
            if (GRAV.Length > 4) // GRAV too long
                GRAV = GRAV.Substring(0, 4);
            else if (GRAV.Length < 4) // GRAV too short
                GRAV = GRAV.PadRight(4);

            grav = GRAV.ToUpper();
            this.path = path;

            rand = new Random();
            data = new Dictionary<string, string>();

            if (!ReadSafeFile() && defaultData != null && defaultData.Count != 0)
            {
                // safe file did not yet exist or is corrupted
                // use default data and write it to the file
                data = defaultData;
                WriteSafeFile();
            }
        }

        protected void WriteSafeFile()
        {
            if (data.Count == 0) // no data yet
                return;

            StringBuilder safeData = new StringBuilder(";");

            foreach(KeyValuePair<string, string> pair in data)
                safeData.AppendFormat("{0}={1};", pair.Key, pair.Value); // add all variables to the string

            safeData.Remove(safeData.Length - 1, 1); // get rid of the last ;

            byte[] encryptedSafeData = Encrypt(safeData.ToString()); // encrypt the data

            // write to safe file
            FileStream safeFile = new FileStream(path, FileMode.Create, FileAccess.Write);
            safeFile.Write(encryptedSafeData, 0, encryptedSafeData.Length);
        }

        protected bool ReadSafeFile()
        {
            try
            {
                // read file for data
                FileStream safeFile = new FileStream(path, FileMode.Open);
                List<byte> encryptedSafeData = new List<byte>();
                int nextByte = safeFile.ReadByte();
                while(nextByte != -1)
                {
                    encryptedSafeData.Add((byte)nextByte);
                    nextByte = safeFile.ReadByte();
                }

                string safeData = Decrypt(encryptedSafeData); // decrypt safe file

                if (safeData == "")
                    return false;

                safeData = safeData.Substring(1); // get rid of the first ;
                string[] variablePairs = safeData.Split(';'); // get the variable pairs

                for (int i = 0; i < variablePairs.Length; i++)
                {
                    string[] keyValue = variablePairs[i].Split('='); // split pairs to separate keys and values
                    data.Add(keyValue[0], keyValue[1]); // add to data keeper
                }
                return true;
            }
            catch
            {
                // safe does not yet exist
                return false;
            }
            
        }

        private byte[] Encrypt(string data)
        {
            List<byte> encryptedData = new List<byte>();

            // header
            for (int i = 0; i < 4; i++) // GRAV
                encryptedData.Add((byte)grav[i]);
            for (int i = 0; i < 4; i++) // padding
                encryptedData.Add(0);
            byte[] dataLength = BitConverter.GetBytes(data.Length); // length of the data string
            for (int i = 0; i < 4; i++)
                encryptedData.Add(dataLength[i]);
            for (int i = 0; i < 4; i++) // padding
                encryptedData.Add(0);

            // data
            int offset = 0;
            for(int i = 0; i < data.Length; i++)
            {
                if(data[i] == ';')
                {
                    // new key value pair, use new encryption value
                    offset = rand.Next(3, 13);
                    encryptedData.Add((byte)offset);
                }
                else
                {
                    int temp = data[i] - 32; // set ASCII start to 0
                    temp += i * offset; // offset as encryption
                    temp = temp % 224; // get back in ascii range
                    temp += 32; // set back to normal
                    encryptedData.Add((byte)temp);
                }
            }

            return encryptedData.ToArray();
        }

        private string Decrypt(List<byte> encryptedData)
        {
            if (encryptedData.Count < 16)
            {
                // not even header is complete
                // don't load the data
                return "";
            }

            // check header fields
            if (((char)encryptedData[0]).ToString() + ((char)encryptedData[1]).ToString() + ((char)encryptedData[2]).ToString() + ((char)encryptedData[3]).ToString() != grav)
            {
                // incorrect GRAV
                // user may be cheating
                // don't load the data
                return "";
            }
            for (int i = 4; i < 8; i++)
                if(encryptedData[i] != 0)
                {
                    // padding not empty
                    // user may be cheating
                    // don't load the data
                    return "";
                }
            if (encryptedData[8] + encryptedData[9] * 256 + encryptedData[10] * 65536 + encryptedData[11] * 16777216 != encryptedData.Count - 16)
            {
                // length of data is not the same as data length check field
                // user may be cheating
                // don't load the data
                return "";
            }
            for (int i = 12; i < 16; i++)
                if (encryptedData[i] != 0)
                {
                    // padding not empty
                    // user may be cheating
                    // don't load the data
                    return "";
                }

            // decrypt data
            string data = "";
            int offset = 0;
            for(int i = 16; i < encryptedData.Count; i++)
            {
                byte nextByte = encryptedData[i];
                if (nextByte < 32)
                {
                    // encryption byte
                    offset = nextByte;
                    data += ";";
                }
                else
                {
                    // data
                    int temp = encryptedData[i] - 32; // set ASCII start to 0
                    temp -= (i - 16) * offset; // offset as encryption
                    while (temp < 0)
                    {
                        // get back in ascii range
                        temp += 224;
                    }
                    temp += 32; // set back to normal
                    data += ((char)temp).ToString();
                }
            }
            
            return data;
        }

        public string File
        { get { return path.Substring(path.LastIndexOf('/') + 1); } }

        public string GRAV
        { get { return GRAV; } }

        public Dictionary<string, string> Data
        { get { return data; } }

        public string GetStringValueOf(string key)
        {
            try { return data[key]; }
            catch { return ""; } // key does not exist
        }

        public int GetIntegerValueOf(string key)
        {
            try { return int.Parse(data[key]); }
            catch { return 0; } // key does not exist or value is not a number
        }

        public double GetDecimalValueOf(string key)
        {
            try { return double.Parse(data[key]); }
            catch { return 0; } // key does not exist or value is not a number
        }

        public bool GetBooleanValueOf(string key)
        {
            try { return bool.Parse(data[key]); }
            catch { return false; } // key does not exist or value is not a boolean
        }
    }
}
