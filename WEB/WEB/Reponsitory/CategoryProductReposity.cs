using Microsoft.AspNetCore.Mvc;
using WEB.Data;

namespace WEB.Reponsitory
{
    public class CategoryProductReposity : ICategotyProductRepository
    {

        private readonly QuanLyBanHangContext _context;

        public CategoryProductReposity(QuanLyBanHangContext context)
        { 
            _context = context;
        }

        public Category Add(Category CategoryName)
        {
            _context.Add(CategoryName);
            _context.SaveChanges();
            return CategoryName;
        }

        public Category Update(Category CategoryName)
        {
            _context.Update(CategoryName);
            _context.SaveChanges();
            return CategoryName;
        }

        public Category Delete(int CategoryID)
        {
            throw new NotImplementedException();
        }

        public Category GetCategoryProduct(int CategoryID)
        {
            return _context.Categories.Find(CategoryID);
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Categories;
        }



    }
}
