using Bookstore.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace Bookstore.Orders
{
    public class OrderAppService : BookstoreAppService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IRepository<Book, Guid> _bookRepository;
        private readonly IRepository<IdentityUser> _userRepository;
        public OrderAppService(IOrderRepository orderRepository,
            IRepository<Book, Guid> bookRepository,
            IRepository<IdentityUser> userRepository)
        {
            _orderRepository = orderRepository;
            _bookRepository = bookRepository;
            _userRepository = userRepository;
        }

        public async Task<OrderDto> GetAsync(Guid id)
        {
            IQueryable<Order> orderQueryable = await _orderRepository.GetQueryableAsync();
            IQueryable<Book> bookQueryable = await _bookRepository.GetQueryableAsync();
            IQueryable<IdentityUser> userQueryable = await _userRepository.GetQueryableAsync();

            var query = from book in bookQueryable
                        join order in orderQueryable on book.Id equals order.BookId
                        where order.Id == id
                        join user in userQueryable on order.UserId equals user.Id
                        select new { book, order, user };

            var queryRes = await AsyncExecuter.FirstOrDefaultAsync(query);

            OrderDto res = ObjectMapper.Map<Order, OrderDto>(queryRes.order);

            res.UserName = queryRes.user.UserName;

            return res;
        }

        public async Task<PagedResultDto<OrderDto>> GetListAsync(GetOrderListDto input)
        {
            IQueryable<Order> orderQueryable = await _orderRepository.GetQueryableAsync();
            IQueryable<Book> bookQueryable = await _bookRepository.GetQueryableAsync();
            IQueryable<IdentityUser> userQueryable = await _userRepository.GetQueryableAsync();

            var query = (from book in bookQueryable
                         join order in orderQueryable on book.Id equals order.BookId
                         join user in userQueryable on order.UserId equals user.Id
                         select new { book, order, user })
                         .Skip(input.SkipCount)
                         .Take(input.MaxResultCount);

            var queryRes = await AsyncExecuter.ToListAsync(query);

            List<OrderDto> res = queryRes.Select(x =>
                {
                    OrderDto order = ObjectMapper.Map<Order, OrderDto>(x.order);
                    order.UserName = x.user.UserName;
                    return order;
                })
                .ToList();
            long totalCount = await _orderRepository.GetCountAsync();

            return new PagedResultDto<OrderDto>(totalCount, res);
        }

        public async Task<OrderDto> CreateAsync(CreateUpdateOrderDto input)
        {
            Order order = ObjectMapper.Map<CreateUpdateOrderDto, Order>(input);
            order.OrderTime = DateTime.Now;

            Order insertRes = await _orderRepository.InsertAsync(order);

            return ObjectMapper.Map<Order, OrderDto>(insertRes);
        }

        public async Task<OrderDto> UpdateAsync(Guid id, CreateUpdateOrderDto input)
        {
            Order order = await _orderRepository.GetAsync(id);

            order.BookId = input.BookId;
            order.Quantity = input.Quantity;

            Order updateRes = await _orderRepository.UpdateAsync(order);
            return ObjectMapper.Map<Order, OrderDto>(updateRes);
        }

        public async Task DeleteAsync(Guid Id)
        {
            await _orderRepository.DeleteAsync(Id);
        }
    }
}
