using System;
using System.Collections.Generic;
using System.Linq;
using Guru.Core.Entities;

namespace Guru.Service.Repo {
    public class MemberContainer
    {
        public Dictionary<int, Member> MemberList { get; set; }

        public MemberContainer()
        {
            MemberList = GetMembers().ToDictionary(itm => itm.Id, itm => itm);
        }
        
        private IEnumerable<Member> GetMembers() 
        {
            for (int i = 0; i < 20; i++)
            {
                yield return new Member {
                    Id = i,
                    Email = $"myemail{i}@gmail.com",
                    CreatedDate = DateTime.Now.AddDays(-i),
                    FirstName = $"FirstName{i}",
                    LastName = $"LastName{i}",
                    Phone = $"{i}{i}{i} {i}{i}{i}",
                    WebSite = $"mypage{i}.com",
                    IsAdministrator = i % 2 == 0
                };
            }
        }
    }
}