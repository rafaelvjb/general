using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TagMyCoins.Application.Interfaces;
using TagMyCoins.Application.ViewModels;
using TagMyCoins.Infra.Data.Context;
using TagMyCoins.Domain.Entities;

namespace TagMyCoins.Application
{
    public class TagAppService : ITagAppService
    {
        private readonly TagMyCoinsContext _context = new TagMyCoinsContext(); 

        public void Add(TagViewModel tagViewModel)
        {
            var tag = Mapper.Map<TagViewModel, Tag>(tagViewModel);

            _context.Tags.Add(tag);
        }

        public ViewModels.TagViewModel GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ViewModels.TagViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(ViewModels.TagViewModel obj)
        {
            throw new NotImplementedException();
        }

        public void Remove(ViewModels.TagViewModel obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ViewModels.TagViewModel> Get(Expression<Func<ViewModels.TagViewModel, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
