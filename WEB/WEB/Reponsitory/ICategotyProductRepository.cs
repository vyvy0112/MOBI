using WEB.Data;

namespace WEB.Reponsitory
{
    public interface ICategotyProductRepository
    {

        Category Add(Category CategoryName);

        Category Update(Category CategoryName);

        Category Delete(int CategoryID);

        Category GetCategoryProduct(int CategoryID);

        IEnumerable<Category> GetAllCategories();
    }
}
