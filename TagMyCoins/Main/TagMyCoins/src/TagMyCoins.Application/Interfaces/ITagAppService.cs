using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TagMyCoins.Application.ViewModels;

namespace TagMyCoins.Application.Interfaces
{
    public interface ITagAppService
    {
        void Add(TagViewModel obj);
        TagViewModel GetById(Guid id);
        IEnumerable<TagViewModel> GetAll();
        void Update(TagViewModel obj);
        void Remove(TagViewModel obj);
        IEnumerable<TagViewModel> Get(Expression<Func<TagViewModel, bool>> predicate);
    }
}
