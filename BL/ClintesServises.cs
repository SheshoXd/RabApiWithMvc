using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using RabApiWithMvc.Models;
using RabApiWithMvc.ModelViews;

namespace RabApiWithMvc.BL
{
    public class ClintesServises
    {
        RapetsDbContext Db = new RapetsDbContext();
           
        //    public List<ClientAccountVM> GetClientAcc ()
        //{
        //    //var temp = Db.Clients.ToList();
        //    //var tempAcc = Db.ClientAccounts.ToList();
        //    //var LastEntitys = from d in temp
        //    //                  join a in temp
        //    //                  on new { d.ClntId } equals new { }
        //    //                  select new ClientAccountVM
        //    //                  {
        //    //                      ClntAccId = d.ClientAccounts.FirstOrDefault().ClntAccId,
        //    //                      ClntName = d.ClntName,
        //    //                      ClntCreditor = d.ClientAccounts.Sum(x => x.ClntCreditor),
        //    //                      ClntDebit = d.ClientAccounts.Sum(x => x.ClntDebit),
        //    //                      //  ClntBalance = d.ClientAccounts.Sum(x => x.ClntCreditor) + d.ClientAccounts.Sum(x => x.ClntDebit),
        //    //                      // ClntId = d.ClntId,

        //    //                  };

        //    //               return LastEntitys.ToList();
        //}

         

    }
}