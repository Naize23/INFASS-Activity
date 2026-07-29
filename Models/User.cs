namespace INFASS_Activity.Models
{
    public class User
    {
        public string fullname { get; set; } = "";
        public string username { get; set; } = "";

        public string tablename { get; set; } = "";

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

        public string SelectAll(string TBname) 
        {
            string sql = "SELECT * FROM" + " " + TBname;
            return sql;
        }

        public string Delete(string TBname, string condition)
        {
            string sql = "DELETE * FROM" + " " + TBname + "\n" +
                         "WHERE" + " " + condition;
            return sql;
        }

        public string Update(string TBname, string[] fields, string[] values)
        {
            string setclause = "";

            for(int i = 0;i< fields.Length;i++)
            {
                setclause += fields[i] + " = ";
                if(int.TryParse(values[i], out _))
                {
                    setclause += values[i];
                }
                else
                {
                    setclause += "'" + values[i] + "'";
                }

                if(i< fields.Length - 1)
                {
                    setclause += ", \n";
                }
            }

            string output = "UPDATE " + TBname + "\n" +
                            "SET " + setclause+ "\n" +
                            "WHERE StudentID = 1";
            return output;
        }
    }
}