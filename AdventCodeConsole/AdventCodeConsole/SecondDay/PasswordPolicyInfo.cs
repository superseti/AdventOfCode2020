using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCodeConsole.SecondDay
{
    internal class PasswordPolicyInfo<T>
     where T : PasswordPolicy, new()
    {
        public PasswordPolicyInfo(string policyPassword)
        {
            var data = policyPassword.Split(':');
            this.Password = data[1].TrimStart();
            this.PolicyInfo = new T();
            this.PolicyInfo.Initialize(data[0]);
            this.IsValid = this.PolicyInfo.IsPasswordValid(this.Password);
        }
        public string Password { get; private set; }
        public T PolicyInfo { get; private set; }
        public bool IsValid { get; private set; }
    }
}