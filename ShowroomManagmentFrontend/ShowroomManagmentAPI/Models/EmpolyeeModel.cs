﻿using ShowroomManagmentAPI.Data;
using ShowroomManagmentAPI.DTOs;
using ShowroomManagmentAPI.Repositories;

namespace ShowroomManagmentAPI.Models
{
    public class EmpolyeeModel : IEmpolyee
    {
        private readonly ApplicationDbContext dbContext;
        private IWebHostEnvironment webHostEnvironment;

        public EmpolyeeModel(ApplicationDbContext dbContext, IWebHostEnvironment webHostEnvironment)
        {
            this.dbContext = dbContext;

            this.webHostEnvironment = webHostEnvironment;

        }
        public async Task<ResponseDTO> AddEmpolyee(EmpolyeeDTO empolyeeDTO)
        {
            var response = new ResponseDTO();
            try
            {
                string path = null;
                if (empolyeeDTO.ProfileImage != null)
                {
                    var filename = empolyeeDTO.ProfileImage.FileName;

                    // Use an absolute path based on web root
                    string uploadsDirectory = Path.Combine(webHostEnvironment.WebRootPath, "Uploads");
                     path = Path.Combine(uploadsDirectory, filename);

                    // Ensure the directory exists
                    if (!Directory.Exists(uploadsDirectory))
                    {
                        Directory.CreateDirectory(uploadsDirectory);
                    }

                    using (Stream stream = new FileStream(path, FileMode.Create))
                    {
                        await empolyeeDTO.ProfileImage.CopyToAsync(stream);
                    }
                }

            

                var empolyee = new Empolyee()
                {
                    Name = empolyeeDTO.Name,
                    Email = empolyeeDTO.Email,
                    Cnic = empolyeeDTO.Cnic,
                    Address = empolyeeDTO.Address,
                    City = empolyeeDTO.City,
                    Contact_no = empolyeeDTO.Contact_no,
                    DepartmentId = empolyeeDTO.DepartmentId,
                    ProfileImage = path,
                };
                await dbContext.Empolyees.AddAsync(empolyee);
                await dbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
            }
            return response;
        }
    }
}
