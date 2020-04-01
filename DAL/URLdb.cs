using BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
  public  class URLdb
    {
      private LinkHubDbEntities db;

      public URLdb()
      {
          db = new LinkHubDbEntities();
      }

      public IEnumerable<tbl_Url> GetAll()
      {
          return db.tbl_Url.ToList();
      }
      public tbl_Url GetByID(int Id) {

          return db.tbl_Url.Find(Id);
      }
      public void Insert(tbl_Url url) {

           db.tbl_Url.Add(url);
           Save();

      }
      public void Delete(int Id)
      {
          tbl_Url url = db.tbl_Url.Find(Id);
          db.tbl_Url.Remove(url);
      }
     public  void Update(tbl_Url url) 
      {
        //  db.Entry(url).State = EntityState.Modified;
          db.Entry(url).State = EntityState.Modified;
          db.Configuration.ValidateOnSaveEnabled = false;
          Save();
          db.Configuration.ValidateOnSaveEnabled = true;
      }
      public void Save()
      {
          db.SaveChanges();
      }
    }
}
