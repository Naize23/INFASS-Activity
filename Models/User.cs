namespace INFASS_Activity.Models
{
    public class User
    {
        public string username { get; set; } = "";

        public string fullname { get; set; } = "";

        public string email { get; set; } = "";

        public string password { get; set; } = "";

        public string Display(string[] fields, string[] values,string tableName)
        {
            string val = "";
            string field = "";
            for (int i =0; i < fields.Length; i++)
            {
               
                field += fields[i];

                if(i< fields.Length - 1)
                {
                    field += ",";
                }
            }

            for(int i = 0; i< values.Length; i++)
            {
                
              

                if (int.TryParse(values[i], out _))
                {
                    val += values[i];
                }
                else
                {
                    val += "'" + values[i] + "'";
                }

                if(i< values.Length - 1)
                {
                    val+= ",";
                }
            }
            return "INSERT INTO" + " " + tableName + "(" + field +")"+ "\n" +
                    "VALUES" + "("+val +")";
            
        }

       
    }
}