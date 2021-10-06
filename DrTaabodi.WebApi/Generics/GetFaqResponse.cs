using System.Collections.Generic;
using DrTaabodi.WebApi.DTO.QnAs;

namespace DrTaabodi.WebApi.Generics
{
    public record GetFaqResponse
    {
        public int CurrentPage { get; init; }

        public int TotalItems { get; init; }

        public int TotalPages { get; init; }

        public List<ReadQnAs> Items { get; init; }
    }
}
