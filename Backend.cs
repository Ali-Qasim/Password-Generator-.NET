using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace PasswordGenerator
{
    [ApiController]
    [Route("[controller]")]
    public class PasswordController : ControllerBase
    {
        private readonly Password _passwordGenerator;

        public PasswordController()
        {
            _passwordGenerator = new Password(includeLowercase: true, includeUppercase: true, includeNumbers: true, includeSymbols: true);
        }

        [HttpGet("{length}")]
        public ActionResult<string> GetPassword(int length)
        {
            var generatedPassword = _passwordGenerator.Generate(length);
            return generatedPassword;
        }
    }

    public class Password
    {
        private readonly List<string> _characterGroups = new List<string>();

        public Password(bool includeLowercase, bool includeUppercase, bool includeNumbers, bool includeSymbols)
        {
            if (includeLowercase)
            {
                _characterGroups.Add("abcdefghijklmnopqrstuvwxyz");
            }

            if (includeUppercase)
            {
                _characterGroups.Add("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
            }

            if (includeNumbers)
            {
                _characterGroups.Add("0123456789");
            }

            if (includeSymbols)
            {
                _characterGroups.Add("!@#$%^&*()_+-={}[]\\|:;<>,.?/~`");
            }
        }

        public string Generate(int length)
        {
            var rng = new Random();
            var passwordChars = new List<char>();

            for (int i = 0; i < length; i++)
            {
                var randomGroup = _characterGroups[rng.Next(_characterGroups.Count)];
                passwordChars.Add(randomGroup[rng.Next(randomGroup.Length)]);
            }

            return new string(passwordChars.ToArray());
        }
    }
}
