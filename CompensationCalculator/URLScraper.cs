using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompensationCalculator
{
    public class URLScraper
    {
        string url = "http://www.bestplaces.net/cost-of-living/{0}/{1}/50000";
        string xPath = "//*[@id=\"mainContent_dgCOL\"]";

        public CostOfLiving LoadCOLTable(string currentCity, string destinationCity )
        {
            // Load from Url
            url = string.Format(url, currentCity, destinationCity);
            var web = new HtmlWeb();
            var doc = web.Load(url);
                                                          
            // Get the rows from the table
            var query = from table in doc.DocumentNode.SelectNodes(xPath).Cast<HtmlNode>()
                        from row in table.SelectNodes("tr").Cast<HtmlNode>().Skip(1)
                        select row.SelectNodes("th|td").Cast<HtmlNode>();

            // Transform to only get inner text from the nodes
            var values = query.Select(x => x.ToList().Select(y => y.InnerText)).ToList();

            CostOfLiving col = new CostOfLiving();
            // Set all properties from values in table
            foreach (var item in typeof(CostOfLiving).GetProperties())
            {
                var itemVals = values.Where(x => x.ToArray()[0].Equals(item.Name));
                if (itemVals.Count() > 0)
                {
                    item.SetValue(col, itemVals.Single().ToList());
                }
            }

            col.FillCOL();
            return col;
        }

    }
    public class CostOfLiving
    {
        public List<string> Overall { get; protected set; }
        public List<string> Food { get; protected set; }
        public List<string> Housing { get; protected set; }
        public List<string> Utilities { get; protected set; }
        public List<string> Transportation { get; protected set; }
        public List<string> Health { get; protected set; }
        public List<string> Miscellaneous { get; protected set; }

        public double OverallMultiplier => ComparisonMultiplier(Overall);
        public double FoodMultiplier => ComparisonMultiplier(Food);
        public double HousingMultiplier => ComparisonMultiplier(Housing);
        public double UtilitiesMultiplier => ComparisonMultiplier(Utilities);
        public double TransportationMultiplier => ComparisonMultiplier(Transportation);
        public double HealthMultiplier => ComparisonMultiplier(Health);
        public double MiscellaneousMultiplier => ComparisonMultiplier(Miscellaneous);

        public Dictionary<string, double> MultiplierDict;
        public CostOfLiving()
        {
        }

        public void FillCOL()
        {
            MultiplierDict = new Dictionary<string, double>()
            {
                { Overall[0], OverallMultiplier },
                { Food[0], FoodMultiplier },
                { Housing[0], HousingMultiplier },
                { Utilities[0], UtilitiesMultiplier },
                { Transportation[0], TransportationMultiplier },
                { Health[0], HealthMultiplier },
                { Miscellaneous[0], MiscellaneousMultiplier }
            };
        }

        private double ComparisonMultiplier(List<string> values)
        {
            var val = 1.0;
            if (values != null && values.Count > 2)
            {
                if(double.TryParse(values[1], out double sourceMultiplier) && 
                   double.TryParse(values[2], out double destinationMultiplier))
                {
                    val = destinationMultiplier / sourceMultiplier;
                }
            }
            return val;
        }
    }
}
