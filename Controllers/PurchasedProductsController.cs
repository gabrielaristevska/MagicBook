using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Project.Models;

namespace Project.Controllers
{
    [Authorize(Roles ="Administrator,User")]
    public class PurchasedProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PurchasedProducts
        [Authorize]
        public ActionResult Index()
        {
            string UserId = User.Identity.GetUserId();
            return View(db.PurchasedProducts.Where(product => product.UserId.Equals(UserId)).ToList());
        }

       

        public ActionResult Create(int? id, string returnURL)
        {
            var book = db.Books.Find(id);
            string UserId = User.Identity.GetUserId();
            if (db.PurchasedProducts.Where(product => product.UserId.Equals(UserId)).ToList().Exists(product => product.BookId == id))
            {
                return Redirect(returnURL);
            }
            else
            {
                PurchasedProduct purchasedProduct = new PurchasedProduct();
                purchasedProduct.BookId = book.Id;
                purchasedProduct.UserId = User.Identity.GetUserId();
                purchasedProduct.ImageURL = book.ImageUrl;
                purchasedProduct.Name = book.Name;
                purchasedProduct.Description = book.Description;
                purchasedProduct.Price = book.Price;
                purchasedProduct.Genre = book.Genre;
                purchasedProduct.Author = book.Author;
                purchasedProduct.Date = book.Date;
                purchasedProduct.LongDesc = book.DetailsDescription;
                purchasedProduct.DescImg = purchasedProduct.DescImg;

                db.PurchasedProducts.Add(purchasedProduct);
                db.SaveChanges();
                return Redirect(returnURL);
            }

        }

        public ActionResult Delete(int? id)
        {
            PurchasedProduct purchasedProduct = db.PurchasedProducts.Find(id);
            db.PurchasedProducts.Remove(purchasedProduct);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult EmptyCart()
        {
            string UserId = User.Identity.GetUserId();
            var products = db.PurchasedProducts.Where(product => product.UserId.Equals(UserId)).ToList();
            db.PurchasedProducts.RemoveRange(products);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
