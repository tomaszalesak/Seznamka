using Domain.Entities;

namespace Application.DTOs
{
    class UserPreviewDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Bio { get; set; }
        public UserPhoto Photo { get; set; }
    }
}
