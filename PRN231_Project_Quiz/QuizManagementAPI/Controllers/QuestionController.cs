﻿using BusinessObject.Models;
using DTO.DTO_Service;
using DTO.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using System.Reflection;

namespace QuizManagementAPI.Controllers
{

    public class QuestionController : ODataController
    {
        private readonly QuestionService questionService;
        public QuestionController(QuestionService questionService)
        {
            this.questionService = questionService;
        }

        [EnableQuery]
        public ActionResult<IQueryable<QuestionDTO>> Get()
        {
            return Ok(questionService.GetQuestion().AsQueryable());
        }

        public IActionResult Post([FromBody] QuestionDTO question)
        {
            questionService.SaveQuestion(question);
            return Ok();
        }
        public IActionResult Put([FromRoute] int key, [FromBody] QuestionDTO question)
        {
            var tmp = questionService.GetQuestion(key);
            if (tmp == null) { return NotFound(); }
            Type type = typeof(QuestionDTO);
            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                object value = property.GetValue(question);
                property.SetValue(tmp, value);
            }
            questionService.UpdateQuestion(tmp);
            return Ok();
        }
        public IActionResult Delete([FromRoute] int key)
        {
            var tmp = questionService.GetQuestion(key);
            if (tmp == null) { return NotFound(); }
            questionService.DeleteQuestion(tmp);
            return Ok();
        }
    }
}
