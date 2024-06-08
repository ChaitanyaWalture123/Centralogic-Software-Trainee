﻿using Chaitanya_Walture_Assignment4.CosmosDB;
using Chaitanya_Walture_Assignment4.DTO;
using Chaitanya_Walture_Assignment4.Entities;
using Chaitanya_Walture_Assignment4.Interfaces;

namespace Chaitanya_Walture_Assignment4.Services
{
    public class VisitorService : IVisitorService

    {
        public readonly ICosmosDBService _icsmosDBService;
        public VisitorService(ICosmosDBService cosmosDBService) 
        {
            _icsmosDBService = cosmosDBService;
        }

        public async Task<RequestDTO> ApproveRequsest(String Id)
        {
            var existingRecord = await _icsmosDBService.GetVisitorByVisitorId(Id);

            existingRecord.Archieved = true;
            existingRecord.Active = false;
            var response = await _icsmosDBService.ReplaceRecord(existingRecord, Id);

            existingRecord.Id=Guid.NewGuid().ToString();
            existingRecord.UpdatedBy = "Office User";
            existingRecord.UpdatedOn = DateTime.Now;
            existingRecord.Version = existingRecord.Version + 1;
            existingRecord.Archieved= false;
            existingRecord.Active= true;

            existingRecord.Name = response.Name;
            existingRecord.Email = response.Email;
            existingRecord.PhoneNumber = response.PhoneNumber;
            existingRecord.Address = response.Address;
            existingRecord.VisitingTo = response.VisitingTo;
            existingRecord.Purpose = response.Purpose;
            existingRecord.EntryTime = response.EntryTime;
            existingRecord.ExitTime = response.ExitTime;
            existingRecord.Status = "Approved";

            existingRecord = await _icsmosDBService.RegisterVisitor(existingRecord);

            RequestDTO requestDTO = new RequestDTO();
            requestDTO.Name = existingRecord.Name;
            requestDTO.Email = existingRecord.Email;
            requestDTO.PhoneNumber = existingRecord.PhoneNumber;
            requestDTO.Address = existingRecord.Address;
            requestDTO.VisitingTo = existingRecord.VisitingTo;
            requestDTO.Purpose = existingRecord.Purpose;
            requestDTO.EntryTime = existingRecord.EntryTime;
            requestDTO.ExitTime = existingRecord.ExitTime;
            requestDTO.Status = existingRecord.Status;

            return requestDTO;




        }

        public async Task<List<VisitorDTO>> GetAllRequest()
        {
            var response = await _icsmosDBService.GetAllVisitors();
            var responseModels = new List<VisitorDTO>();
            foreach(var visitor in response)
            {
                var responseModel = new VisitorDTO();
                responseModel.Name = visitor.Name;
                responseModel.Email = visitor.Email;
                responseModel.PhoneNumber = visitor.PhoneNumber;
                responseModel.Address = visitor.Address;
                responseModel.VisitingTo = visitor.VisitingTo;
                responseModel.Purpose = visitor.Purpose;
                responseModel.EntryTime = visitor.EntryTime;
                responseModel.ExitTime = visitor.ExitTime;

                responseModels.Add(responseModel);
            }
            return responseModels;
        }

        public async Task<List<RequestDTO>> GetApprovedRequest()
        {
            var response = await _icsmosDBService.GetApprovedRequest();
            var responseModels = new List<RequestDTO>();
            foreach (var visitor in response)
            {
                var responseModel = new RequestDTO();
                responseModel.Name = visitor.Name;
                responseModel.Email = visitor.Email;
                responseModel.PhoneNumber = visitor.PhoneNumber;
                responseModel.Address = visitor.Address;
                responseModel.VisitingTo = visitor.VisitingTo;
                responseModel.Purpose = visitor.Purpose;
                responseModel.EntryTime = visitor.EntryTime;
                responseModel.ExitTime = visitor.ExitTime;
                responseModel.Status= visitor.Status;
                responseModels.Add(responseModel);
            }
            return responseModels;
        }

        public async Task<RequestDTO> GetVisitorByVisitorId(string visitorId)
        {
            var visitor = await _icsmosDBService.GetVisitorByVisitorId(visitorId);
            
            var responseModel = new RequestDTO();
            responseModel.Name = visitor.Name;
            responseModel.Email = visitor.Email;
            responseModel.PhoneNumber = visitor.PhoneNumber;
            responseModel.Address = visitor.Address;
            responseModel.VisitingTo = visitor.VisitingTo;
            responseModel.Purpose = visitor.Purpose;
            responseModel.EntryTime = visitor.EntryTime;
            responseModel.ExitTime = visitor.ExitTime;
            responseModel.Status = visitor.Status;

            return responseModel;

            
        }

        public async Task<List<RequestDTO>> PendingRequest()
        {
            var response = await _icsmosDBService.PendingRequest();
            var responseModels = new List<RequestDTO>();
            foreach (var visitor in response)
            {
                var responseModel = new RequestDTO();
                responseModel.Name = visitor.Name;
                responseModel.Email = visitor.Email;
                responseModel.PhoneNumber = visitor.PhoneNumber;
                responseModel.Address = visitor.Address;
                responseModel.VisitingTo = visitor.VisitingTo;
                responseModel.Purpose = visitor.Purpose;
                responseModel.EntryTime = visitor.EntryTime;
                responseModel.ExitTime = visitor.ExitTime;
                responseModel.Status = visitor.Status;
                responseModels.Add(responseModel);
            }
            return responseModels;
        }

        public async Task<VisitorDTO> RegisterVisitor(VisitorDTO visitor)
        {
            VisitorEntity visitorEntity=new VisitorEntity();
            visitorEntity.Name = visitor.Name;
            visitorEntity.Email = visitor.Email;
            visitorEntity.PhoneNumber = visitor.PhoneNumber;
            visitorEntity.Address = visitor.Address;
            visitorEntity.VisitingTo = visitor.VisitingTo;
            visitorEntity.Purpose = visitor.Purpose;
            visitorEntity.EntryTime = visitor.EntryTime;
            visitorEntity.ExitTime= visitor.ExitTime;
            visitorEntity.Status = "Pending";

            visitorEntity.Id=Guid.NewGuid().ToString();
            visitorEntity.UId= visitorEntity.Id;
            visitorEntity.DocumentType = "Visitor";
            visitorEntity.CreatedOn = DateTime.Now;
            visitorEntity.CreatedByName = "chaitanya";
            visitorEntity.UpdatedOn = DateTime.Now;
            visitorEntity.UpdatedBy = "Chaitanya";
            visitorEntity.Version = 1;
            visitorEntity.Active = true;
            visitorEntity.Archieved = false;

            var response= await _icsmosDBService.RegisterVisitor(visitorEntity);

            var responseModel = new VisitorDTO();
            responseModel.Name=visitor.Name;
            responseModel.Email=visitor.Email;
            responseModel.PhoneNumber=visitor.PhoneNumber;
            responseModel.Address=visitor.Address;
            responseModel.VisitingTo = visitor.VisitingTo;
            responseModel.Purpose = visitor.Purpose;    
            responseModel.EntryTime = visitor.EntryTime;
            responseModel.ExitTime= visitor.ExitTime;
 
            return responseModel;


        }

        public async Task<List<RequestDTO>> RejectedRequest()
        {
            var response = await _icsmosDBService.RejectedRequest();
            var responseModels = new List<RequestDTO>();
            foreach (var visitor in response)
            {
                var responseModel = new RequestDTO();
                responseModel.Name = visitor.Name;
                responseModel.Email = visitor.Email;
                responseModel.PhoneNumber = visitor.PhoneNumber;
                responseModel.Address = visitor.Address;
                responseModel.VisitingTo = visitor.VisitingTo;
                responseModel.Purpose = visitor.Purpose;
                responseModel.EntryTime = visitor.EntryTime;
                responseModel.ExitTime = visitor.ExitTime;
                responseModel.Status = visitor.Status;
                responseModels.Add(responseModel);
            }
            return responseModels;
        }

        public async Task<RequestDTO> RejectRequest(string id)
        {
            var existingRecord = await _icsmosDBService.GetVisitorByVisitorId(id);

            existingRecord.Archieved = true;
            existingRecord.Active = false;
            var response = await _icsmosDBService.ReplaceRecord(existingRecord, id);

            existingRecord.Id = Guid.NewGuid().ToString();
            existingRecord.UpdatedBy = "Office User";
            existingRecord.UpdatedOn = DateTime.Now;
            existingRecord.Version = existingRecord.Version + 1;
            existingRecord.Archieved = false;
            existingRecord.Active = true;

            existingRecord.Name = response.Name;
            existingRecord.Email = response.Email;
            existingRecord.PhoneNumber = response.PhoneNumber;
            existingRecord.Address = response.Address;
            existingRecord.VisitingTo = response.VisitingTo;
            existingRecord.Purpose = response.Purpose;
            existingRecord.EntryTime = response.EntryTime;
            existingRecord.ExitTime = response.ExitTime;
            existingRecord.Status = "Rejected";

            existingRecord = await _icsmosDBService.RegisterVisitor(existingRecord);

            RequestDTO requestDTO = new RequestDTO();
            requestDTO.Name = existingRecord.Name;
            requestDTO.Email = existingRecord.Email;
            requestDTO.PhoneNumber = existingRecord.PhoneNumber;
            requestDTO.Address = existingRecord.Address;
            requestDTO.VisitingTo = existingRecord.VisitingTo;
            requestDTO.Purpose = existingRecord.Purpose;
            requestDTO.EntryTime = existingRecord.EntryTime;
            requestDTO.ExitTime = existingRecord.ExitTime;
            requestDTO.Status = existingRecord.Status;

            return requestDTO;


        }
    }
}
