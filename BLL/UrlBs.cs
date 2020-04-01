using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class UrlBs
    {
       private URLdb objDb;

       public UrlBs()
      {
          objDb = new URLdb();
      }

      public IEnumerable<tbl_Url> GetAll()
      {
          return objDb.GetAll();
      }
      public tbl_Url GetByID(int Id) {

          return objDb.GetByID(Id);
      }
      public void Insert(tbl_Url url) {

          objDb.Insert(url);
          
      }
      public void Delete(int Id)
      {

          objDb.Delete(Id);
      }
      public void Update(tbl_Url url) 
      {
          objDb.Update(url);
      }
     
    }
}
