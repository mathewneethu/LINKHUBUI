﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public  class BaseBs
    {
        public CategoryBs categoryBs { get; set; }
        public UserBs userBs { get; set; }
        public UrlBs urlbs { get; set; }
        public BaseBs()
        {
            categoryBs = new CategoryBs();
            userBs = new UserBs();
            urlbs = new UrlBs();

        }
   }
}
