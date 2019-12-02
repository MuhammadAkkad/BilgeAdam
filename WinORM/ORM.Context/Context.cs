using System.Collections.Generic;

namespace ORM.Context
{
    public class Context
    {
        string cnnString;
        public Context(string cnn)
        {
            cnnString = cnn;
        }

        private List<object> list = new List<object>();

        public void Add(object entity) {

            string value = entity.GetType().GetProperty("CategoryName").GetValue(entity).ToString();

            //list.Add(entity);

        }

        public bool SaveChanges() {

            foreach (var item in list) { 
            
            }
            return true;
        }
    }
}
