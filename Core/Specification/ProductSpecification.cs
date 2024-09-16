using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{
    public class ProductSpecification : BaseSpecification<Product>
    {
        public ProductSpecification(ProductSpecPrams specPrams) : base(x =>
        (string.IsNullOrEmpty(specPrams.Search) || x.Name.ToLower().Contains(specPrams.Search)) &&
         (!specPrams.Brands.Any() || specPrams.Brands.Contains(x.Brand)) &&
         (!specPrams.Types.Any() || specPrams.Types.Contains(x.Type))
        )
        {
            ApplyPaging(specPrams.PageSize * (specPrams.PageIndex - 1), specPrams.PageSize);

            switch (specPrams.Sort)
            {
                case "priceAsc":
                    AddOrderBy(x => x.Price);
                    break;

                case "priceDesc":
                    AddOrderByDescending(x => x.Price);
                    break;
                default:
                    AddOrderBy(x => x.Name);
                    break;
            }
        }
    }
}
