using AllBizz.Business.DTOs.MemberDtos;
using AllBizz.Business.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AllBizz.Api.Controllers
{
    [Route("api/members")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var members = await _memberService.GetAllAsync();
            return Ok(members);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var member = await _memberService.GetByIdAsync(id);
            if (member == null)
            {
                return NotFound();
            }
            return Ok(member);
        }

        [HttpPost]
        //[Authorize(Roles = "SuperAdmin,Admin")]
        [ProducesResponseType(typeof(int), 201)]
        public async Task<IActionResult> Create([FromForm] MemberCreateDto dto)
        {
           
                await _memberService.Create(dto);
                return Ok("Member created successfully");
            
        }

        [HttpPut("{id}")]
        //[Authorize(Roles = "SuperAdmin,Admin")]
        [ProducesResponseType(typeof(int), 201)]
        [ProducesResponseType(typeof(int), 404)]
        public async Task<IActionResult> Update( [FromForm] MemberUpdateDto dto)
        {
           
            try
            {
                await _memberService.Update(dto);
                return Ok("Member updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "SuperAdmin")]
        [ProducesResponseType(typeof(int), 201)]
        [ProducesResponseType(typeof(int), 404)]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _memberService.Delete(id);
                return Ok("Member deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }

        [HttpPatch("{id}")]
        //[Authorize(Roles ="SuperAdmin,Admin")]
        [ProducesResponseType(typeof(int), 201)]
        [ProducesResponseType(typeof(int), 404)]
        public async Task<ActionResult> SoftDelete(int id)
        {
            try
            {
                await _memberService.SoftDelete(id);
                return Ok("Member soft deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }
    }
}
