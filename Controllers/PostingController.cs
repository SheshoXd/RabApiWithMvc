using RabApiWithMvc.Models;
using RabApiWithMvc.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Http;
using Microsoft.VisualBasic;


namespace RabApiWithMvc.Controllers
{

    
    /*
       Configuration.ProxyCreationEnabled = false;
            Configuration.AutoDetectChangesEnabled = true;
            Configuration.LazyLoadingEnabled = false;
     */
    public class PostingController :ApiController
    {
        private RapetsDbContext db = new RapetsDbContext();

             [HttpGet]
        public HttpResponseMessage TranspurchsOrder(int id)
             {
                 HttpResponseMessage M = new HttpResponseMessage();
              
                 
                 var entity =
                     db.PurchaseOrders.Where(x => x.OrderId == id)
                         .Include(x => x.PurchaseOrdersDetails)
                         .FirstOrDefault();
                 if (entity != null && entity.PostingStats != 1) { 
            //Check if the supplier have Acc
            var SuppAccTemp = db.SuppliersAccounts.Where(x => x.SuppId == entity.SuppId).Include(s=>s.Supplier).FirstOrDefault();
            if (SuppAccTemp == null)
            {
             SuppliersAccount newSuppAcc = new SuppliersAccount();
                newSuppAcc.SuppId = entity.SuppId;
                newSuppAcc.SuppCreditor = entity.Creditor.HasValue ? entity.Creditor.Value : 0;
                    newSuppAcc.SuppDebit = entity.Debit.HasValue ? entity.Debit.Value : 0;
                    db.Entry(newSuppAcc).State = EntityState.Added;
                db.SuppliersAccounts.Add(newSuppAcc);
                db.SaveChanges();
            }
            else
            {
              SuppAccTemp.SuppDebit += entity.Debit.HasValue?  entity.Debit.Value :0 ;
                SuppAccTemp.SuppCreditor += entity.Creditor.HasValue ? entity.Creditor.Value : 0;
                    db.Entry(SuppAccTemp).State = EntityState.Modified;
                db.SuppliersAccounts.Add(SuppAccTemp);
                db.SaveChanges();
            }

                 Journal jor = new Journal();
                 jor.jorAmount = entity.TotalPrice;
                 jor.jornalType = 1;
                 jor.jorText = "عملية شراء من " + SuppAccTemp.Supplier.SuppName;
                 jor.Debit = entity.Debit;
                 jor.creadit = entity.Creditor;
                db.Entry(jor).State = EntityState.Added;
                 db.Journals.Add(jor);
                 db.SaveChanges();
                 M.Content = new StringContent( jor.jorText+  "ترحيل");
                 if (entity.Debit > 1)
                 {
                     Debit deb = new Debit();
                     deb.SuppID = entity.SuppId;
                     deb.DebitAmount = entity.Debit;
                     db.Entry(deb).State = EntityState.Added;
                     db.Debits.Add(deb);
                     db.SaveChanges();

                 }

                    Cash csh = new Cash();
                 csh.PayType = "سحب نقدى";
                 csh.Creditor = -entity.Creditor;
                 db.Entry(csh).State = EntityState.Added;
                 db.Cashes.Add(csh);
                 db.SaveChanges();
                 


                 foreach (var VARIABLE in entity.PurchaseOrdersDetails)
             {
                  var olditem =   db.StoreItems.Where(x => x.ItemId == VARIABLE.itemId).FirstOrDefault();
                  if (olditem == null)
                  { 
                      StoreItem st = new StoreItem();
                      st.ItemId  = VARIABLE.itemId.GetValueOrDefault();
                      st.itemQyt = VARIABLE.QtyReq.GetValueOrDefault();
                     st.availableQty += VARIABLE.StoredQty.GetValueOrDefault();
                     db.Entry(st).State = EntityState.Added;
                      db.StoreItems.AddOrUpdate(st);
                      db.SaveChanges();
                  }
                  else
                  {
                      olditem.itemQyt += VARIABLE.QtyReq.GetValueOrDefault();
                      olditem.availableQty += VARIABLE.StoredQty.GetValueOrDefault();
                      db.Entry(olditem).State = EntityState.Modified;
                      //db.StoreItems.Add(olditem);
                      db.SaveChanges();
                  }
                     StoreMovement stm = new StoreMovement();
                 stm.ItemId = VARIABLE.itemId;
                 stm.MovementType = 1;
                 stm.OrderDetailsId = entity.OrderId;
                     stm.DateCreated = DateTime.Now;
                 stm.itemQty = VARIABLE.QtyReq.GetValueOrDefault();
                     db.Entry(stm).State = EntityState.Added;
                 db.StoreMovements.AddOrUpdate(stm);
                 db.SaveChanges();

             }

                var lastGet = db.PurchaseOrders.Where(d => d.OrderId == entity.OrderId && d.OrderType == entity.OrderType && d.Id == entity.Id)
                         .FirstOrDefault();

                 lastGet.PostingStats = 1;
                 db.Entry(lastGet).State = EntityState.Modified;
               db.PurchaseOrders.AddOrUpdate(lastGet);
                 db.SaveChanges();

                
                 }
                 else
                 {
                     M.Content = new StringContent("this item is posted before");
                 }
                 return M;
             }


        [HttpGet]
             public HttpResponseMessage TransSealOrder(int id)
        {





            HttpResponseMessage M = new HttpResponseMessage();

            var BigTran = db.Database.BeginTransaction();

            try
            {
                
          

  


         var entity =  db.SaleOrders.Where(x => x.SlOrdId == id).Include(x => x.SaleOrdersDetails).FirstOrDefault();
         if (entity != null && entity.PostingStats != 1) {
             var ClintEntity = db.Clients.Where(x => x.ClntId == entity.ClntId).FirstOrDefault();
             var ClintAccTemp = db.ClientAccounts.Where(x => x.ClntId == entity.ClntId).Include(d=>d.Client).FirstOrDefault();
             if (ClintAccTemp == null)
             {
                 ClientAccount newClintAcc = new ClientAccount();
                 newClintAcc.ClntId = entity.ClntId;
               newClintAcc.ClntCreditor = entity.Creditor.GetValueOrDefault();
                 newClintAcc.ClntDebit = entity.Debit.GetValueOrDefault();
                 db.Entry(newClintAcc).State = EntityState.Added;
                 db.ClientAccounts.Add(newClintAcc);
                 db.SaveChanges();
             }
             else
             {
                 ClintAccTemp.ClntDebit += entity.Debit.GetValueOrDefault();
               //  ClintAccTemp.ClntCreditor += entity.Creditor.GetValueOrDefault();
                 db.Entry(ClintAccTemp).State = EntityState.Modified;
                 db.ClientAccounts.Add(ClintAccTemp);
                 db.SaveChanges();
             }

             Journal jor = new Journal();
             jor.jorAmount = entity.TotalPrice;
             jor.jornalType = 2;
             jor.jorText = " عملية بيع الى " + ClintEntity.ClntName;
             jor.Debit = entity.Debit;
            // jor.creadit = 
             db.Entry(jor).State = EntityState.Added;
             db.Journals.Add(jor);
             db.SaveChanges();
             M.Content = new StringContent(jor.jorText + "ترحيل");
             //if (entity.Debit > 1)         // لاتوجد لها اهميه  17*12*2017
             //{
             //    //Debit deb = new Debit();
             //    //deb.SuppID = entity.ClntId;
             //    //deb.DebitAmount = entity.Debit;
             //    //db.Entry(deb).State = EntityState.Added;
             //    //db.Debits.Add(deb);
             //    //db.SaveChanges();
             //    Creadit crd = new Creadit();
             //    crd.ClintId = entity.ClntId;
             //    crd.CreaditAmount = entity.Creditor.GetValueOrDefault();
             //    db.Entry(crd).State = EntityState.Added;
             //    db.Creadits.Add(crd);
             //    db.SaveChanges();
             //}


             //  التحصيل منفصل عن تسجيل و ترحل عمليات البيع

             //Cash csh = new Cash();
             //csh.PayType = "ايداع نقدى";
             //csh.Creditor += entity.Debit;
             //db.Entry(csh).State = EntityState.Added;
             //db.Cashes.Add(csh);
             //db.SaveChanges();
                 
            foreach (var VARIABLE in entity.SaleOrdersDetails)
            {
                var newMovNum = 1;
                try
                { newMovNum += db.StoreMovements.Max(x => x.StoremoveId); }
                catch { }
            //make store trans 

                StoreMovement stm = new StoreMovement();
                stm.ItemId = VARIABLE.ItemId;
                stm.MovementType = 2;
                stm.OrderDetailsId = entity.SlOrdId;
                stm.DateCreated = DateTime.Now;
                stm.itemQty = VARIABLE.SlQty;
                db.Entry(stm).State = EntityState.Added;
                db.StoreMovements.Add(stm);
                db.SaveChanges();
                //////////////////
                // نريد اضافة خصم من حساب المخزن هنا

                try
                {
               
                    var storeItemtemp = db.StoreItems.Where(x => x.StoreItemId == VARIABLE.ItemId).FirstOrDefault();
                    if (storeItemtemp != null)
                    {
                        storeItemtemp.itemQyt += -VARIABLE.SlQty.GetValueOrDefault();
                        db.Entry(storeItemtemp).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                     M.Content = new StringContent("الصنف غير متاح بالمخازن");
                    }

                  
                }
                catch (Exception ex)
                {
                    
                    throw ex;
                }


              

            }
            entity.PostingStats = 1;
            db.Entry(entity).State = EntityState.Modified;
            db.SaleOrders.AddOrUpdate(entity);
            db.SaveChanges();
           
            Vaucher nVau = new Vaucher();
            nVau.ClntId = entity.ClntId;
            nVau.SlOrdId = entity.SlOrdId;
            nVau.VauAmount = entity.TotalPrice;
             
            if (ClintAccTemp.ClntDebit != null) { 
               nVau.VauOldAmunt = ClintAccTemp.ClntDebit;
                    }
             else
            {

                nVau.VauOldAmunt = 0;
            }
                   
             NumberToText ntt = new NumberToText();
             nVau.VauAmoTxt = ntt.ArabicNumToText((nVau.VauAmount + nVau.VauOldAmunt).ToString(), "فقط (", " )جنيهاُ");
            // Number2Text.ArabicNumToText((nVau.VauAmount + nVau.VauOldAmunt).ToString(), "فقط (", " )جنيهاُ");
             db.Entry(nVau).State = EntityState.Added;
             db.Vauchers.AddOrUpdate(nVau);
             db.SaveChanges();
        }// end if entity is not null
         else
         {
             if (entity == null)
             {
                 M.Content = new StringContent("Ecourng erorr");
             }
             else
             {
                 M.Content = new StringContent("this item is posted before");  
             }
         }
         BigTran.Commit();
            }
              
            catch (Exception Ex)
            {
                BigTran.Rollback();

                throw Ex;
            }
            
            return M;
        }


        [HttpGet]
        public HttpResponseMessage PostRequestSealOrder(int id)
        {

            HttpResponseMessage M = new HttpResponseMessage();

            var BigTran = db.Database.BeginTransaction();

            try
            {

                var entity = db.SaleOrders.Where(x => x.SlOrdId == id).Include(x => x.SaleOrdersDetails).FirstOrDefault();
                if (entity != null && entity.PostingStats != 1)
                {

                    Vaucher isVaucher = new Vaucher();
                   var newWno= 1;
                          NumberToText ntt = new NumberToText();
                    try {  newWno += db.Vauchers.Max(f => f.VauId); }
                    catch { }
                    decimal? DepOnClint = decimal.MinValue;
                    try {DepOnClint = db.ClientAccounts.Where(x => x.ClntId == entity.ClntId).Select(d=>d.ClntDebit).FirstOrDefault(); }
                    catch { }
                   

               
                    foreach (var myItem in entity.SaleOrdersDetails)
                    {

                        //var newMovNum = 1;
                        //try
                        //{ newMovNum += db.StoreMovements.Max(x => x.StoremoveId); }
                        //catch { }
                        //make store trans 
                           /// اضافه مستند حركه فى المخازن
                        StoreMovement stm = new StoreMovement();
                        stm.ItemId = myItem.ItemId;
                        stm.MovementType = 2;
                        stm.OrderDetailsId = entity.SlOrdId;
                        stm.DateCreated = DateTime.Now;
                        stm.itemQty = myItem.SlQty;
                        db.Entry(stm).State = EntityState.Added;
                        db.StoreMovements.Add(stm);
                        db.SaveChanges();
                        //////////////////
                      //  isVaucher.VauId = newWno;
                                            /// خصم كميات من المخازن
                            var storeItemtemp = db.StoreItems.Where(x => x.StoreItemId == myItem.ItemId).FirstOrDefault();
                            if (storeItemtemp != null)
                            {

                                storeItemtemp.UnPostedQty = storeItemtemp.UnPostedQty - myItem.SlQty.GetValueOrDefault();
                                storeItemtemp.availableQty = storeItemtemp.itemQyt + storeItemtemp.UnPostedQty.GetValueOrDefault();
                                db.Entry(storeItemtemp).State = EntityState.Modified;
                                db.StoreItems.AddOrUpdate(storeItemtemp);
                                db.SaveChanges();
                            }
                            else
                            {
                                M.Content = new StringContent("الصنف غير متاح بالمخازن");
                            }
                            isVaucher.VauAmount = isVaucher.VauAmount.GetValueOrDefault() + myItem.TotalPrice.GetValueOrDefault()
;
                            VaucherDetile VaDet = new VaucherDetile();
                           VaDet.ItemId = myItem.ItemId;
                           VaDet.qty = myItem.SlQty.GetValueOrDefault();
                          // VaDet.VauId = newWno;
                          VaDet.TotalPrice = myItem.TotalPrice.GetValueOrDefault();
                          VaDet.ItemPrice = myItem.ItemPrice.GetValueOrDefault();
                          VaDet.CaseNo = myItem.CaseNumber;
                          VaDet.CaseWds = myItem.CaseWight.GetValueOrDefault();
                      
                        db.Entry(VaDet).State = EntityState.Added;
                       isVaucher.VaucherDetiles.Add(VaDet);
                       

                    }
                    // 
                    isVaucher.ClntId = entity.ClntId;
                    isVaucher.VauStatus = false;
                    isVaucher.VauOldAmunt = DepOnClint;
                    isVaucher.VauDate = entity.SlOrdDate;
                    var totAmou = DepOnClint.GetValueOrDefault() + isVaucher.VauAmount.GetValueOrDefault();
                    isVaucher.VauAmoTxt = ntt.ArabicNumToText(totAmou.ToString(), "فقط (", " )جنيهاُ");

                    db.Entry(isVaucher).State = EntityState.Added;
                    db.Vauchers.AddOrUpdate(isVaucher);
                    db.SaveChanges();

                
                    var ClintEntity = db.Clients.Where(x => x.ClntId == entity.ClntId).FirstOrDefault();
                    Journal jor = new Journal();
                    jor.jorAmount = entity.TotalPrice;
                    jor.jornalType = 2;
                    jor.jorText = " ترحيل امر  بيع من  " + ClintEntity.ClntName;
                    jor.Debit = entity.Debit;
                    // jor.creadit = 
                    db.Entry(jor).State = EntityState.Added;
                    db.Journals.Add(jor);
                    db.SaveChanges();
                    M.Content = new StringContent(jor.jorText + "ترحيل");


                    Journal jor2 = new Journal();
                    jor2.jorAmount = entity.TotalPrice;
                    jor2.jornalType = 5;
                    jor2.jorText = "  سحب اصناف من المخزن  " ;
                    jor2.creadit = entity.TotalPrice;
                    // jor.creadit = 
                    db.Entry(jor2).State = EntityState.Added;
                    db.Journals.Add(jor2);
                    db.SaveChanges();
                   // M.Content =  M.Content + new StringContent(jor2.jorText) ;
                    M.Content = new StringContent(jor.jorText +jor2.jorText+ " ترحيل(2) و سحب اصناف من المخازن(5) " );


                
                    entity.PostingStats = 1;
                    db.Entry(entity).State = EntityState.Modified;
                    db.SaleOrders.AddOrUpdate(entity);
                    db.SaveChanges();

              
                }// end if entity is not null
                else
                {
                    if (entity == null)
                    {
                        M.Content = new StringContent("Ecourng erorr");
                    }
                    else
                    {
                        M.Content = new StringContent("this item is posted before");
                    }
                }
                BigTran.Commit();
            }

            catch (Exception Ex)
            {
                BigTran.Rollback();

                throw Ex;
            }

            return M;
        }
           [HttpGet]
        public HttpResponseMessage PostVaucher(int id)
        {
            HttpResponseMessage M = new HttpResponseMessage();
            var bGtrn = db.Database.BeginTransaction();
            try
            {
               
                //جلب الفاتوره للترحيل
           var entity = db.Vauchers.Where(x => x.VauId == id).Include(i => i.VaucherDetiles).FirstOrDefault();
              
                   
                        // لو موجوده
                   if (entity  != null)
                   {   



                       var newClintAcc = db.ClientAccounts.Where(d => d.ClntId == entity.ClntId).FirstOrDefault();
                       // newClintAcc.ClntId = entity.ClntId;
                       newClintAcc.ClntCreditor = entity.VauAmount.GetValueOrDefault();
                       newClintAcc.MoveType = "SL";
                       db.Entry(newClintAcc).State = EntityState.Modified;
                       db.ClientAccounts.Add(newClintAcc);
                       db.SaveChanges();

                       #region المخازن
                                   // الدوران فى التفاصيل
                       foreach (var myItem in entity.VaucherDetiles)
                       {
                                       // خصم الكميات من المخزن
                           var storeItemtemp = db.StoreItems.Where(x => x.StoreItemId == myItem.ItemId).FirstOrDefault();
                           if (storeItemtemp != null)
                           {

                               storeItemtemp.UnPostedQty = storeItemtemp.UnPostedQty.GetValueOrDefault() + myItem.qty.GetValueOrDefault();
                               storeItemtemp.itemQyt = storeItemtemp.itemQyt - myItem.qty.GetValueOrDefault();
                               storeItemtemp.availableQty = storeItemtemp.itemQyt + storeItemtemp.UnPostedQty.GetValueOrDefault();
                               db.Entry(storeItemtemp).State = EntityState.Modified;
                               db.StoreItems.Add(storeItemtemp);
                               db.SaveChanges();
                           }
                           else
                           {
                               M.Content = new StringContent("الصنف غير متاح بالمخازن");
                           }
                       }
                       #endregion
                       // انشاء قيد حساب مخزن

                      StoreAccount newStAcc = new Models.StoreAccount();

                      newStAcc.StoreDebit = entity.VauAmount;
                      newStAcc.RefType = "IS";
                      newStAcc.RefId = entity.VauId;
                      db.Entry(newStAcc).State = EntityState.Added;
                      db.StoreAccount.AddOrUpdate(newStAcc);
                      db.SaveChanges();

                      #region       // تعديل فى القيود العامه
                      
                      
                      // جلب قيد المخازن
                      var GLAccStTemp = db.GLAccounts.Where(x => x.AccId == entity.ClntId && x.AccType == "ST").FirstOrDefault();
                      if (GLAccStTemp == null)
                      {       // انشاء قيد عام جديد ان لام يوجد
                          GLAccount glAccSt = new GLAccount();
                          glAccSt.GLAccId = 1;
                          glAccSt.GLDebit = 0;
                          glAccSt.GlCreditor = entity.VauAmount;
                          glAccSt.GLBalance = entity.VauAmount;
                          glAccSt.AccType = "ST";
                          db.Entry(glAccSt).State = EntityState.Modified;
                          db.GLAccounts.Add(glAccSt);
                          db.SaveChanges();

                      }
                      else
                      {       // تعديل على القيد الموجود
                          GLAccStTemp.GlCreditor += entity.VauAmount.GetValueOrDefault();
                          GLAccStTemp.GLBalance = GLAccStTemp.GLDebit.GetValueOrDefault() - GLAccStTemp.GlCreditor.GetValueOrDefault();
                          db.Entry(GLAccStTemp).State = EntityState.Modified;
                          db.GLAccounts.Add(GLAccStTemp);
                          db.SaveChanges();
                      }
                       

                                 //   قيد العميل
                      var GLAccCiTemp = db.GLAccounts.Where(x => x.AccId == entity.ClntId && x.AccType == "CI").FirstOrDefault();
                      if (GLAccCiTemp == null)
                      {                //  انشاء 
                          GLAccount glAccCi = new GLAccount();
                          glAccCi.GLAccId = entity.ClntId.Value;
                          glAccCi.GLDebit = 0;
                          glAccCi.GlCreditor = entity.VauAmount;
                          glAccCi.GLBalance = entity.VauAmount;
                          glAccCi.AccType = "CI";
                          db.Entry(glAccCi).State = EntityState.Modified;
                          db.GLAccounts.Add(glAccCi);
                          db.SaveChanges();
                      }
                      else
                      {            //تغديل
                          GLAccCiTemp.GlCreditor += entity.VauAmount.GetValueOrDefault();
                          GLAccCiTemp.GLBalance = GLAccCiTemp.GLDebit.GetValueOrDefault() - GLAccCiTemp.GlCreditor.GetValueOrDefault();
                          db.Entry(GLAccCiTemp).State = EntityState.Modified;
                          db.GLAccounts.Add(GLAccCiTemp);
                          db.SaveChanges();
                      }
                       #endregion

                      var ClintEntity = db.Clients.Where(x => x.ClntId == entity.ClntId).FirstOrDefault();

                       // قيد يوميه

                      Journal jor = new Journal();
                      jor.jorAmount = entity.VauAmount;
                      jor.jornalType = 3;
                      jor.jorText = " ترحيل فاتوره بيع للعميل  " + ClintEntity.ClntName + " بمبلغ" + entity.VauAmount;
                      jor.Debit = entity.VauAmount;
                      // jor.creadit = 
                      db.Entry(jor).State = EntityState.Added;
                      db.Journals.Add(jor);
                      db.SaveChanges();
                      M.Content = new StringContent(jor.jorText + "ترحيل");



                      entity.VauStatus = true;
                      db.Entry(entity).State = EntityState.Modified;
                      db.Vauchers.AddOrUpdate(entity);
                      db.SaveChanges();
                  }
                   bGtrn.Commit();
            }
            catch(Exception ex)
            {
                bGtrn.Rollback();
            }

            return M;
        }


    }

    public class NumberToText
    {

        #region Fields
        //Fields for Arabic Numbers
        private string[] onesA = new string[11];
        private string[] TensA = new string[11];
        private string[] HunderdsA = new string[11];
        private string[] ThousandsA = new string[11];
        private string[] MillionsA = new string[11];
        private string[] MilliarsA = new string[11];
        private string[] TrillionsA = new string[11];
        private string TeensA;
        //Fields for English Numbers
        private string[] ones = new string[11];
        private string[] Teens = new string[11];
        private string[] Tens = new string[11];
        private string[] Thousands = new string[6];
        #endregion

        #region Constructor and Initialization
        /// <summary>
        /// Class Constructor
        /// </summary>
        public NumberToText()
        {
            InitNumbers();
        }
        private void InitNumbers()
        {
            //English Numbers
            ones[0] = "zero";
            ones[1] = "one";
            ones[2] = "two";
            ones[3] = "three";
            ones[4] = "four";
            ones[5] = "five";
            ones[6] = "six";
            ones[7] = "seven";
            ones[8] = "eight";
            ones[9] = "nine";
            Teens[0] = "ten";
            Teens[1] = "eleven";
            Teens[2] = "twelve";
            Teens[3] = "thirteen";
            Teens[4] = "fourteen";
            Teens[5] = "fifteen";
            Teens[6] = "sixteen";
            Teens[7] = "seventeen";
            Teens[8] = "eighteen";
            Teens[9] = "nineteen";
            Tens[0] = "";
            Tens[1] = "ten";
            Tens[2] = "twenty";
            Tens[3] = "thirty";
            Tens[4] = "forty";
            Tens[5] = "fifty";
            Tens[6] = "sixty";
            Tens[7] = "seventy";
            Tens[8] = "eighty";
            Tens[9] = "ninety";
            Thousands[0] = "";
            Thousands[1] = "thousand"; // US numbering
            Thousands[2] = "million";
            Thousands[3] = "billion";
            Thousands[4] = "trillion";

            //Arabic Numbers
            TeensA = "ون";
            onesA[0] = "صفر";
            onesA[1] = "واحد";
            onesA[2] = "إثنان";
            onesA[3] = "ثلاث";
            onesA[4] = "أربع";
            onesA[5] = "خمس";
            onesA[6] = "ست";
            onesA[7] = "سبع";
            onesA[8] = "ثمان";
            onesA[9] = "تسع";
            TensA[0] = "عشر";
            TensA[1] = "إحدى";
            TensA[2] = "إثنى";
            TensA[3] = "ثلاثة";
            TensA[4] = "أربعة";
            TensA[5] = "خمسة";
            TensA[6] = "ستة";
            TensA[7] = "سبعة";
            TensA[8] = "ثمانية";
            TensA[9] = "تسعة";
            HunderdsA[0] = "";
            HunderdsA[1] = "مائة";
            HunderdsA[2] = "مائت" + "ان";
            HunderdsA[3] = onesA[3] + "مائة";
            HunderdsA[4] = onesA[4] + "مائة";
            HunderdsA[5] = onesA[5] + "مائة";
            HunderdsA[6] = onesA[6] + "مائة";
            HunderdsA[7] = onesA[7] + "مائة";
            HunderdsA[8] = onesA[8] + "مائة";
            HunderdsA[9] = onesA[9] + "مائة";
            ThousandsA[0] = "";
            ThousandsA[1] = "ألف";
            ThousandsA[2] = "ألف" + "ان";
            ThousandsA[3] = TensA[3] + " " + "آلاف";
            ThousandsA[4] = TensA[4] + " " + "آلاف";
            ThousandsA[5] = TensA[5] + " " + "آلاف";
            ThousandsA[6] = TensA[6] + " " + "آلاف";
            ThousandsA[7] = TensA[7] + " " + "آلاف";
            ThousandsA[8] = TensA[8] + " " + "آلاف";
            ThousandsA[9] = TensA[9] + " " + "آلاف";
            MillionsA[0] = "";
            MillionsA[1] = "مليون";
            MillionsA[2] = "مليونان";
            MillionsA[3] = TensA[3] + " " + "ملايين";
            MillionsA[4] = TensA[4] + " " + "ملايين";
            MillionsA[5] = TensA[5] + " " + "ملايين";
            MillionsA[6] = TensA[6] + " " + "ملايين";
            MillionsA[7] = TensA[7] + " " + "ملايين";
            MillionsA[8] = TensA[8] + " " + "ملايين";
            MillionsA[9] = TensA[9] + " " + "ملايين";
            MilliarsA[0] = "";
            MilliarsA[1] = "مليار";
            MilliarsA[2] = "ملياران";
            MilliarsA[3] = onesA[3] + " " + "مليارات";
            MilliarsA[4] = onesA[4] + " " + "مليارات";
            MilliarsA[5] = onesA[5] + " " + "مليارات";
            MilliarsA[6] = onesA[6] + " " + "مليارات";
            MilliarsA[7] = onesA[7] + " " + "مليارات";
            MilliarsA[8] = onesA[8] + " " + "مليارات";
            MilliarsA[9] = onesA[9] + " " + "مليارات";
            TrillionsA[0] = "";
            TrillionsA[1] = "تريليون";
            TrillionsA[2] = "تريليونان";
            TrillionsA[3] = TensA[3] + " " + "تريليونات";
            TrillionsA[4] = TensA[4] + " " + "تريليونات";
            TrillionsA[5] = TensA[5] + " " + "تريليونات";
            TrillionsA[6] = TensA[6] + " " + "تريليونات";
            TrillionsA[7] = TensA[7] + " " + "تريليونات";
            TrillionsA[8] = TensA[8] + " " + "تريليونات";
            TrillionsA[9] = TensA[9] + " " + "تريليونات";
        }
        #endregion

        #region Number-To-Text Functions

        #region English Number-To-Text
        /// <summary>
        /// Returns a string representing the text of a given number in English
        /// </summary>
        /// <param name="Number">The input number (long) to be translated into text</param>
        /// <param name="LeadingString">A string to be added to the beginning of the number</param>
        /// <param name="LaggingString">A string to be added to the end of the number</param>
        /// <returns>An English string equivalent to the number</returns>
        public string EnglishNumToText(long Number, string LeadingString, string LaggingString)
        {
            int nCol = 0, nChar = 0;
            bool bAllZeros = true; // Non-zero digit not yet encountered
            bool bShowThousands = false;
            string strBuff = null, strTemp = null;
            string strVal = Number.ToString();

            if (Strings.Len(strVal) > 15)
            {
                strBuff = "#Error#";
                return strBuff;
            }
            else
            {
                // Trap errors
                try
                {
                    // Iterate through string
                    for (int i = Strings.Len(strVal); i >= 1; i += -1)
                    {
                        // Get value of this digit
                        nChar = System.Convert.ToInt32(Conversion.Val(Strings.Mid(strVal, i, 1)));
                        // Get column position
                        nCol = (Strings.Len(strVal) - i) + 1;
                        // Action depends on 1's, 10's or 100's column
                        switch ((nCol % 3))
                        {
                            case 1:
                                bShowThousands = true;
                                if (i == 1)
                                {
                                    // First digit in number (last in the loop)
                                    strTemp = ones[nChar] + " ";
                                }
                                else if (Strings.Mid(strVal, i - 1, 1) == "1")
                                {
                                    // This digit is part of "teen" number
                                    strTemp = Teens[nChar] + " ";
                                    i = i - 1; // Skip tens position
                                }
                                else if (nChar > 0)
                                {
                                    // Any non-zero digit
                                    strTemp = ones[nChar] + " ";
                                }
                                else
                                {
                                    // This digit is zero. If digit in tens and hundreds column
                                    // are also zero, don't show "thousands"
                                    bShowThousands = false;
                                    // Test for non-zero digit in this grouping
                                    if (Strings.Mid(strVal, i - 1, 1) != "0")
                                    {
                                        bShowThousands = true;
                                    }
                                    else if (i > 2)
                                    {
                                        if (Strings.Mid(strVal, i - 2, 1) != "0")
                                        {
                                            bShowThousands = true;
                                        }
                                    }
                                    strTemp = "";
                                }
                                // Show "thousands" if non-zero in grouping
                                if (bShowThousands)
                                {
                                    if (nCol > 1)
                                    {
                                        strTemp = strTemp + Thousands[nCol / 3];
                                        if (bAllZeros)
                                        {
                                            strTemp = strTemp + " ";
                                        }
                                        else
                                        {
                                            strTemp = strTemp + ", ";
                                        }
                                    }
                                    // Indicate non-zero digit encountered
                                    bAllZeros = false;
                                }
                                strBuff = strTemp + strBuff;
                                break;
                            case 2:
                                if (nChar > 0)
                                {
                                    if (Strings.Mid(strVal, i + 1, 1) != "0")
                                    {
                                        strBuff = Tens[nChar] + "-" + strBuff;
                                    }
                                    else
                                    {
                                        strBuff = Tens[nChar] + " " + strBuff;
                                    }
                                }
                                break;
                            case 0:
                                if (nChar > 0)
                                {
                                    strBuff = ones[nChar] + " hundred " + strBuff;
                                }
                                break;
                        }
                    }
                    // Convert first letter to upper case
                    strBuff = Strings.UCase(Strings.Left(strBuff, 1)) + Strings.Mid(strBuff, 2);
                    // Return result
                    return LeadingString + strBuff.TrimEnd() + LaggingString;
                }
                catch
                {
                    //goto NumToTextError;
                    strBuff = "#Error#";
                    return strBuff;
                }
            }
        }

        /// <summary>
        /// Returns a string representing the text of a given number in English
        /// </summary>
        /// <param name="Number">The input number (long) to be translated into text</param>
        /// <returns>An English string equivalent to the number</returns>
        public string EnglishNumToText(long Number)
        {
            return EnglishNumToText(Number, "");
        }

        /// <summary>
        /// Returns a string representing the text of a given number in English
        /// </summary>
        /// <param name="Number">The input number (long) to be translated into text</param>
        /// <param name="LeadingString">A string to be added to the beginning of the number</param>
        /// <returns>An English string equivalent to the number</returns>
        public string EnglishNumToText(long Number, string LeadingString)
        {
            return EnglishNumToText(Number, LeadingString, "");
        }
        /// <summary>
        /// Returns a string representing the text of a given number in English
        /// </summary>
        /// <param name="Number">The input number (string) to be translated into text</param>
        /// <param name="LeadingString">A string to be added to the beginning of the number</param>
        /// <param name="LaggingString">A string to be added to the end of the number</param>
        /// <returns>An English string equivalent to the number</returns>
        public string EnglishNumToText(string Number, string LeadingString, string LaggingString)
        {
            return EnglishNumToText(System.Convert.ToInt64(Conversion.Val(Number)), LeadingString, LaggingString);
        }
        /// <summary>
        /// Returns a string representing the text of a given number in English
        /// </summary>
        /// <param name="Number">The input number (string) to be translated into text</param>
        /// <returns>An English string equivalent to the number</returns>
        public string EnglishNumToText(string Number)
        {
            return EnglishNumToText(Number, "");
        }
        /// <summary>
        /// Returns a string representing the text of a given number in English
        /// </summary>
        /// <param name="Number">The input number (string) to be translated into text</param>
        /// <param name="LeadingString">A string to be added to the beginning of the number</param>
        /// <returns>An English string equivalent to the number</returns>
        public string EnglishNumToText(string Number, string LeadingString)
        {
            return EnglishNumToText(Number, LeadingString, "");
        }
        #endregion

        #region Arabic Number-To-Text
        /// <summary>
        /// Returns a string representing the text of a given number in Arabic
        /// </summary>
        /// <param name="Number">The input number (long) to be translated into text</param>
        /// <param name="LeadingString">A string to be added to the beginning of the number</param>
        /// <param name="LaggingString">A string to be added to the end of the number</param>
        /// <returns>An Arabic string equivalent to the number</returns>
        public string ArabicNumToText(long Number, string LeadingString, string LaggingString)
        {
            string NumToTextA = null;
            string strVal = Number.ToString();

            if (strVal == "0")
            {
                NumToTextA = aOnes("0");
                return LeadingString + NumToTextA + LaggingString;
            }

            switch (Strings.Len(strVal))
            {
                case 1:
                    NumToTextA = aOnes(strVal);
                    break;
                case 2:
                    NumToTextA = aTens(strVal);
                    break;
                case 3:
                    NumToTextA = aHunderds(strVal);
                    break;
                case 4:
                    NumToTextA = aThousands(strVal);
                    break;
                case 5:
                    NumToTextA = aTenThousands(strVal);
                    break;
                case 6:
                    NumToTextA = aHunderdThousands(strVal);
                    break;
                case 7:
                    NumToTextA = aMillions(strVal);
                    break;
                case 8:
                    NumToTextA = aTenMillions(strVal);
                    break;
                case 9:
                    NumToTextA = aHunderdMillions(strVal);
                    break;
                case 10:
                    NumToTextA = aMilliars(strVal);
                    break;
                case 11:
                    NumToTextA = aTenMilliars(strVal);
                    break;
                case 12:
                    NumToTextA = aHunderdMilliars(strVal);
                    break;
                case 13:
                    NumToTextA = aTrillions(strVal);
                    break;
                case 14:
                    NumToTextA = aTenTrillions(strVal);
                    break;
                case 15:
                    NumToTextA = aHunderdTrillions(strVal);
                    break;
                default:
                    NumToTextA = "#غير معرَّف#";
                    break;
            }

            return LeadingString + NumToTextA + LaggingString;
        }
        /// <summary>
        /// Returns a string representing the text of a given number in Arabic
        /// </summary>
        /// <param name="Number">The input number (long) to be translated into text</param>
        /// <returns>An Arabic string equivalent to the number</returns>
        public string ArabicNumToText(long Number)
        {
            return ArabicNumToText(Number, "");
        }
        /// <summary>
        /// Returns a string representing the text of a given number in Arabic
        /// </summary>
        /// <param name="Number">The input number (long) to be translated into text</param>
        /// <param name="LeadingString">A string to be added to the beginning of the number</param>
        /// <returns>An Arabic string equivalent to the number</returns>
        public string ArabicNumToText(long Number, string LeadingString)
        {
            return ArabicNumToText(Number, LeadingString, "");
        }
        /// <summary>
        /// Returns a string representing the text of a given number in Arabic
        /// </summary>
        /// <param name="Number">The input number (string) to be translated into text</param>
        /// <param name="LeadingString">A string to be added to the beginning of the number</param>
        /// <param name="LaggingString">A string to be added to the end of the number</param>
        /// <returns>An Arabic string equivalent to the number</returns>
        public string ArabicNumToText(string Number, string LeadingString, string LaggingString)
        {
            return ArabicNumToText(System.Convert.ToInt64(Conversion.Val(Number)), LeadingString, LaggingString);
        }
        /// <summary>
        /// Returns a string representing the text of a given number in Arabic
        /// </summary>
        /// <param name="Number">The input number (string) to be translated into text</param>
        /// <returns>An Arabic string equivalent to the number</returns>
        public string ArabicNumToText(string Number)
        {
            return ArabicNumToText(Number, "");
        }
        /// <summary>
        /// Returns a string representing the text of a given number in Arabic
        /// </summary>
        /// <param name="Number">The input number (string) to be translated into text</param>
        /// <param name="LeadingString">A string to be added to the beginning of the number</param>
        /// <returns>An Arabic string equivalent to the number</returns>
        public string ArabicNumToText(string Number, string LeadingString)
        {
            return ArabicNumToText(Number, LeadingString, "");
        }
        #endregion

        #endregion

        #region Private Functions (Needed by ArabicNumToText)
        private string aOnes(string s)
        {
            string aOnes1;

            switch (System.Convert.ToInt32(Conversion.Val(s)))
            {
                case 0:
                case 1:
                case 2:
                    aOnes1 = onesA[System.Convert.ToInt32(Conversion.Val(s))];
                    break;
                case 8:
                    aOnes1 = onesA[System.Convert.ToInt32(Conversion.Val(s))] + "ية";
                    break;
                default:
                    aOnes1 = onesA[System.Convert.ToInt32(Conversion.Val(s))] + "ة";
                    break;
            }

            return aOnes1;
        }

        private string aTens(string s)
        {
            string sr = Strings.Right(s, 1);
            int isr = System.Convert.ToInt32(Conversion.Val(sr));
            string sl = Strings.Left(s, 1);
            int isl = System.Convert.ToInt32(Conversion.Val(sl));

            if (sl == "0")
            {
                return aOnes(sr);
            }

            string aTens1;

            if (sr == "0")
            {
                switch (isl)
                {
                    case 1:
                        aTens1 = TensA[0] + "ة";
                        break;
                    case 2:
                        aTens1 = TensA[0] + TeensA;
                        break;
                    default:
                        aTens1 = onesA[isl] + TeensA;
                        break;
                }
            }
            else
            {
                if (sl == "1")
                {
                    aTens1 = TensA[isr] + " " + TensA[0];
                }
                else
                {
                    if (sl == "2")
                    {
                        aTens1 = TensA[isr] + " و " + TensA[0] + TeensA;
                    }
                    else
                    {
                        aTens1 = onesA[isr] + " و " + onesA[isl] + TeensA;
                    }
                }
            }

            return aTens1;
        }

        private string aHunderds(string s)
        {
            string s1 = Strings.Left(s, 1);
            int is1 = System.Convert.ToInt32(Conversion.Val(s1));
            string s2 = Strings.Mid(s, 2, 1);
            int is2 = System.Convert.ToInt32(Conversion.Val(s2));
            string s3 = Strings.Right(s, 1);
            int is3 = System.Convert.ToInt32(Conversion.Val(s3));
            string s23 = s2 + s3;

            if ((is2 == 0) && (is3 == 0))
            {
                return HunderdsA[is1];
            }

            if (is1 == 0)
            {
                return HunderdsA[is1] + ArabicNumToText(s23);
            }
            else
            {
                return HunderdsA[is1] + " و " + ArabicNumToText(s23);
            }
        }

        private string aThousands(string s)
        {
            string s1 = Strings.Left(s, 1);
            int is1 = System.Convert.ToInt32(Conversion.Val(s1));
            string s234 = Strings.Mid(s, 2);

            if (s234 == "000")
            {
                return ThousandsA[is1];
            }

            if (is1 == 0)
            {
                return ThousandsA[is1] + ArabicNumToText(s234);
            }
            else
            {
                return ThousandsA[is1] + " و " + ArabicNumToText(s234);
            }
        }
        private string aTenThousands(string s)
        {
            string s1 = Strings.Mid(s, 1, 2);
            string s345 = Strings.Mid(s, 3);

            if (Conversion.Val(s345) == 0)
            {
                if (s1 == "10")
                {
                    return ArabicNumToText(s1) + " آلاف";
                }
                else
                {
                    return ArabicNumToText(s1) + " ألف";
                }
            }

            if (s1 == "10")
            {
                return ArabicNumToText(s1) + " آلاف و " + ArabicNumToText(s345);
            }
            else
            {
                return ArabicNumToText(s1) + " ألف و " + ArabicNumToText(s345);
            }

        }
        private string aHunderdThousands(string s)
        {
            string s1 = Strings.Mid(s, 1, 3);
            string s456 = Strings.Mid(s, 4);

            if (Conversion.Val(Strings.Mid(s, 2)) == 0)
            {
                if (Conversion.Val(s) == 200000)
                {
                    return Strings.Left(ArabicNumToText(s1), 5) + " ألف";
                }
                else
                {
                    return ArabicNumToText(s1) + " ألف";
                }
            }

            if (s456 == "000")
            {
                return ArabicNumToText(s1) + " ألف";
            }

            if (s1 == "200")
            {
                return Strings.Left(ArabicNumToText(s1), 5) + " ألف و " + ArabicNumToText(s456);
            }
            else
            {
                return ArabicNumToText(s1) + " ألف و " + ArabicNumToText(s456);
            }
        }
        private string aMillions(string s)
        {
            string s1 = Strings.Mid(s, 1, 1);
            string sr = Strings.Mid(s, 2);

            if (Conversion.Val(sr) == 0)
            {
                return MillionsA[System.Convert.ToInt32(s1)];
            }

            return MillionsA[System.Convert.ToInt32(s1)] + " و " + ArabicNumToText(sr);
        }
        private string aTenMillions(string s)
        {
            string s1 = Strings.Mid(s, 1, 2);
            string sr = Strings.Mid(s, 3);

            if (Conversion.Val(Strings.Mid(s, 2)) == 0)
            {
                if (s1 == "10")
                {
                    return ArabicNumToText(s1) + " ملايين";
                }
                else
                {
                    return ArabicNumToText(s1) + " مليون";
                }
            }

            if (s1 == "10")
            {
                return ArabicNumToText(s1) + " ملايين و " + ArabicNumToText(sr);
            }
            else
            {
                return ArabicNumToText(s1) + " مليون و " + ArabicNumToText(sr);
            }
        }
        private string aHunderdMillions(string s)
        {
            string s1 = Strings.Mid(s, 1, 3);
            string sr = Strings.Mid(s, 4);

            if (Conversion.Val(Strings.Mid(s, 2)) == 0)
            {
                if (Conversion.Val(s) == 200000000)
                {
                    return Strings.Left(ArabicNumToText(s1), 5) + " مليون";
                }
                else
                {
                    return ArabicNumToText(s1) + " مليون";
                }
            }

            if (sr == "000000")
            {
                return ArabicNumToText(s1) + " مليون";
            }
            if (s1 == "200")
            {
                return Strings.Left(ArabicNumToText(s1), 5) + " مليون و " + ArabicNumToText(sr);
            }
            else
            {
                return ArabicNumToText(s1) + " مليون و " + ArabicNumToText(sr);
            }
        }
        private string aMilliars(string s)
        {
            string s1 = Strings.Mid(s, 1, 1);
            string sr = Strings.Mid(s, 2);

            if (Conversion.Val(sr) == 0)
            {
                return MilliarsA[System.Convert.ToInt32(s1)];
            }
            return MilliarsA[System.Convert.ToInt32(s1)] + " و " + ArabicNumToText(sr);
        }
        private string aTenMilliars(string s)
        {
            string s1 = Strings.Mid(s, 1, 2);
            string sr = Strings.Mid(s, 3);

            if (Conversion.Val(Strings.Mid(s, 2)) == 0)
            {
                if (s1 == "10")
                {
                    return ArabicNumToText(s1) + " مليارات";
                }
                else
                {
                    return ArabicNumToText(s1) + " مليار";
                }
            }

            if (s1 == "10")
            {
                return ArabicNumToText(s1) + " مليارات و " + ArabicNumToText(sr);
            }
            else
            {
                return ArabicNumToText(s1) + " مليار و " + ArabicNumToText(sr);
            }
        }
        private string aHunderdMilliars(string s)
        {
            string s1 = Strings.Mid(s, 1, 3);
            string sr = Strings.Mid(s, 4);

            if (Conversion.Val(Strings.Mid(s, 2)) == 0)
            {
                if (Conversion.Val(s) == System.Convert.ToDouble(200000000000))
                {
                    return Strings.Left(ArabicNumToText(s1), 5) + " مليار";
                }
                else
                {
                    return ArabicNumToText(s1) + " مليار";
                }
            }
            if (sr == "000000000")
            {
                return ArabicNumToText(s1) + " مليار";
            }
            if (s1 == "200")
            {
                return Strings.Left(ArabicNumToText(s1), 5) + " مليار و " + ArabicNumToText(sr);
            }
            else
            {
                return ArabicNumToText(s1) + " مليار و " + ArabicNumToText(sr);
            }
        }
        private string aTrillions(string s)
        {
            string s1 = Strings.Mid(s, 1, 1);
            string sr = Strings.Mid(s, 2);

            if (Conversion.Val(sr) == 0)
            {
                return TrillionsA[System.Convert.ToInt32(s1)];
            }
            return TrillionsA[System.Convert.ToInt32(s1)] + " و " + ArabicNumToText(sr);
        }
        private string aTenTrillions(string s)
        {
            string s1 = Strings.Mid(s, 1, 2);
            string sr = Strings.Mid(s, 3);

            if (Conversion.Val(Strings.Mid(s, 2)) == 0)
            {
                if (s1 == "10")
                {
                    return ArabicNumToText(s1) + " تريليونات";
                }
                else
                {
                    return ArabicNumToText(s1) + " تريليون";
                }
            }
            if (s1 == "10")
            {
                return ArabicNumToText(s1) + " تريليونات و " + ArabicNumToText(sr);
            }
            else
            {
                return ArabicNumToText(s1) + " تريليون و " + ArabicNumToText(sr);
            }
        }
        private string aHunderdTrillions(string s)
        {
            string s1 = Strings.Mid(s, 1, 3);
            string sr = Strings.Mid(s, 4);

            if (Conversion.Val(Strings.Mid(s, 2)) == 0)
            {
                if (Conversion.Val(s) == System.Convert.ToDouble(200000000000000))
                {
                    return Strings.Left(ArabicNumToText(s1), 5) + " تريليون";
                }
                else
                {
                    return ArabicNumToText(s1) + " تريليون";
                }
            }
            if (sr == "000000000")
            {
                return ArabicNumToText(s1) + " تريليون";
            }
            if (s1 == "200")
            {
                return Strings.Left(ArabicNumToText(s1), 5) + " تريليون و " + ArabicNumToText(sr);
            }
            else
            {
                return ArabicNumToText(s1) + " تريليون و " + ArabicNumToText(sr);
            }
        }

        #endregion

    }
}


//var ClintEntity = db.Clients.Where(x => x.ClntId == entity.ClntId).FirstOrDefault();
//var ClintAccTemp = db.ClientAccounts.Where(x => x.ClntId == entity.ClntId).FirstOrDefault();
//if (ClintAccTemp == null)
//{
//    ClientAccount newClintAcc = new ClientAccount();
//    newClintAcc.ClntId = entity.ClntId;
//   // newClintAcc.ClntCreditor = entity.Creditor.GetValueOrDefault();
//    newClintAcc.ClntDebit = entity.TotalPrice.GetValueOrDefault();
//    db.Entry(newClintAcc).State = EntityState.Added;
//    db.ClientAccounts.Add(newClintAcc);
//    db.SaveChanges();
//}
//else
//{
//    ClintAccTemp.ClntDebit += entity.TotalPrice.GetValueOrDefault();
//    //  ClintAccTemp.ClntCreditor += entity.Creditor.GetValueOrDefault();
//    db.Entry(ClintAccTemp).State = EntityState.Modified;
//    db.ClientAccounts.Add(ClintAccTemp);
//    db.SaveChanges();
//}

//Journal jor = new Journal();
//jor.jorAmount = entity.TotalPrice;
//jor.jornalType = 2;
//jor.jorText = " طلب بيع من  " + ClintEntity.ClntName;
//jor.Debit = entity.Debit;
//// jor.creadit = 
//db.Entry(jor).State = EntityState.Added;
//db.Journals.Add(jor);
//db.SaveChanges();
//M.Content = new StringContent(jor.jorText + "ترحيل");


