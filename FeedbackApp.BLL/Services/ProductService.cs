using FeedbackApp.BLL.Interfaces;
using FeedbackApp.BLL.VMs.Product;
using FeedbackApp.DAL.Patterns;
using FeedbackApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackApp.BLL.Services
{
    public class ProductService : IProductService
    {
        public ProductService(IUnitOfWork _db)
        {
            db = _db;
        }
        private readonly IUnitOfWork db;

        public async Task<Guid> CreateProductAsync(CreateProduct product)
        {
           try
            {
                var dbProduct = new Product()
                {
                    Name = product.Name,
                    Category = product.Category
                };
                dbProduct = await db.Products.CreateAsync(dbProduct);
                return dbProduct.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CreateProduct> FindProductsByFunc(Func<Product,bool> func)
        {
            try
            {
                var dbProducts = db.Products.GetAll().Where(func). //это чтобы превратить список Product в список CreateProduct
                                                      Select(m=> 
                                                      { 
                                                          return new CreateProduct() 
                                                          { 
                                                              Category=m.Category, Name = m.Name 
                                                          }; 
                                                      }).ToList();
                return dbProducts;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
