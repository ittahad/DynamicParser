public void DynamicObjectParser()
{

 List<string> filter = new List<string> {"Gender", "Name", "Age", "Salary" };

            List<List<string>> data = new List<List<string>> { 
                new List<string> { "Name", "Occupation", "Age", "Salary", "PostCode", "Gender" },
                new List<string> { "Akash", "SE", "24", "35000", "1212", "M" },
                new List<string> { "Imran", "GEO", "32", "140000", "1212", "M" },
                new List<string> { "Arif", "SSE", "39", "700000", "34322", "M" },
                new List<string> { "Sharif", "BM", "64", "100000", "7431", "M" },
                new List<string> { "Rahela", "HW", "56", "12000", "7431", "F" },
            };

            List<string> dataColumns = new List<string>();

            List<Dto> dtos = new List<Dto>();

            bool first = true;
            foreach(List<string> dataList in data)
            {
                if(first)
                {
                    dataColumns.AddRange(dataList);
                    first = !first;
                    continue;
                }

                Dictionary<string, string> dict = new Dictionary<string, string>();
                Dto dtoBuilder = new Dto();

                foreach(string column in dataColumns)
                {
                    if(filter.Exists(item => item == column))
                    {
                        int index = dataColumns.FindIndex(item => item == column);
                        string value = dataList.ElementAt(index);
                        dict.Add(column, value);
                    }

                }

                string jsonString = DictToJson(dict);

                var parsedValue =  Newtonsoft.Json.JsonConvert.DeserializeObject<Dto>(jsonString);


                dtos.Add(parsedValue);
                
            }


}
