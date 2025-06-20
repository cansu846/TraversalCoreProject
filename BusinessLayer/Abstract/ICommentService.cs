﻿using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICommentService:IGenericService<Comment>
    {
        public List<Comment> TGetCommentByDestinationId(int id);
        public List<Comment> TGetCommentListWithDestination();
        public List<Comment> TGetCommentByUserId(int userId);
        public List<Comment> TCommentListWithDestinationAndAppUser(int destinationId);
    }
}
