using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pacman
{

    public enum SortingOrder { Ascending, Descending } // used to determain if a higher value is better or worse

    public class HighscoreKeeper : SafeFileHandler
    {

        protected SortingOrder sorting;
        protected List<KeyValuePair<string, TimeSpan>> highscoreTable;

        public HighscoreKeeper(SortingOrder sorting, string path, string GRAV = "") : base(path, GRAV)
        {
            this.sorting = sorting;
            highscoreTable = new List<KeyValuePair<string, TimeSpan>>();

            if (data.Count == 0)
            {
                // Highscore table not yet made
                ConstructDefaultHighscoreTable();
            }
            else
            {
                // parse data to highscore table
                ParseData();
            }
        }

        private void ConstructDefaultHighscoreTable()
        {
            // TODO: default highscore table
        }

        private void ParseData()
        {
            // TODO: Parse data directory to highscore table list
            bool first = true;
            foreach(KeyValuePair<string, string> entry in data)
            {
                if (first)
                {
                    first = false;
                    highscoreTable[0] = new KeyValuePair<string, TimeSpan>(entry.Key, TimeSpan.FromSeconds(double.Parse(entry.Value)));
                }
                else
                {
                    for(int i = highscoreTable.Count - 1; i >= 0; i++)
                    {
                        if (sorting == SortingOrder.Descending)
                        {
                            // best score has the lowest value
                            if (double.Parse(entry.Value) < highscoreTable[i].Value.TotalSeconds)
                            {
                                highscoreTable.Insert(i, new KeyValuePair<string, TimeSpan>(entry.Key, TimeSpan.FromSeconds(double.Parse(entry.Value))));
                                break;
                            }
                        }
                        else
                        {
                            // best score has the highest value
                            if (double.Parse(entry.Value) > highscoreTable[i].Value.TotalSeconds)
                            {
                                highscoreTable.Insert(i, new KeyValuePair<string, TimeSpan>(entry.Key, TimeSpan.FromSeconds(double.Parse(entry.Value))));
                                break;
                            }
                        }
                    }
                }
            }
        }

    }
}
