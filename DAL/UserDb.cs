﻿using BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class UserDb
    {
         private LinkHubDbEntities db;

         public UserDb()
      {
          db = new LinkHubDbEntities();
      }

      public IEnumerable<tbl_User> GetAll()
      {
          return db.tbl_User.ToList();
      }
      public tbl_User GetByID(int Id)
      {

          return db.tbl_User.Find(Id);
      }
      public void Insert(tbl_User user)
      {

          db.tbl_User.Add(user);
           Save();

      }
      public void Delete(int Id)
      {
          tbl_User user = db.tbl_User.Find(Id);
          db.tbl_User.Remove(user);
      }
      public void Update(tbl_User user) 
      {
          db.Entry(user).State = EntityState.Modified;
      }
      public void Save()
      {
          db.SaveChanges();
      }
    }
}
