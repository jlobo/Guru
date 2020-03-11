using System;
using System.Collections.Generic;
using System.Linq;
using Guru.Core.Entities;

namespace Guru.Service.Repo {
    public class MemberRepo
    {
        private readonly MemberContainer container;

        public MemberRepo(MemberContainer container)
        {
            this.container = container;
        }

        public List<Member> Get() 
        {
            return container.MemberList.Values.ToList();
        }

        public Member Single(int id) 
        {
            if (!container.MemberList.ContainsKey(id))
                return null;
            
            return container.MemberList[id];
        }

        public bool AddOrUpdate(Member member)
        {
            if (member == null || member.Id < 0)
                return false;
            
            container.MemberList[member.Id] = member;
            return true;
        }

        public bool Delete(int id)
        {
            if (!container.MemberList.ContainsKey(id))
                return false;
            
            container.MemberList.Remove(id);
            return true;
        }
    }
}