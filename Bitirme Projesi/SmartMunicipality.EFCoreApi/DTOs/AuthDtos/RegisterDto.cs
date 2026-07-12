 namespace SmartMunicipality.EFCoreApi.DTOs.AuthDtos
    {
        public class RegisterDto
        {
            public string Name { get; set; } = string.Empty;

            public string Surname { get; set; } = string.Empty;

            public string Email { get; set; } = string.Empty;

            public string PhoneNumber { get; set; } = string.Empty;

            public string? TcNo { get; set; }

            public string? Address { get; set; }

            public string? District { get; set; }

            public string Password { get; set; } = string.Empty;
        }
    }

