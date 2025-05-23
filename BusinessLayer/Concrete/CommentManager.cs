using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly ICommentDal _commentDal;
        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }
        public void TAdd(Comment t)
        {
            _commentDal.Insert(t);
        }

        public List<Comment> TCommentListWithDestinationAndAppUser(int destinationId)
        {
            return _commentDal.CommentListWithDestinationAndAppUser(destinationId);
        }

        public void TDelete(Comment t)
        {
           _commentDal.Delete(t);
        }

        public Comment TGetById(int id)
        {
            return _commentDal.GetById(id);
        }

        public List<Comment> TGetCommentByDestinationId(int id)
        {
            return _commentDal.GetListByFilter(x=>x.DestinationId==id);
        }

        public List<Comment> TGetCommentByUserId(int userId)
        {
            return _commentDal.GetListByFilter(x=>x.AppUserId==userId);
        }

        public List<Comment> TGetCommentListWithDestination()
        {
            return _commentDal.CommentListWithDestination();
        }

        public List<Comment> TGetList()
        {
            return _commentDal.GetList();
        }

        public void TUpdate(Comment t)
        {
            throw new NotImplementedException();
        }
    }
}
