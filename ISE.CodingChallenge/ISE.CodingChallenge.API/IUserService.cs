namespace ISE.CodingChallenge.API
{
    public interface IUserService
    {
        /// <summary>
        /// get user json {"Name":"Tess Tickle", "MailNickname":"tess.tickle@sofunny.ha"}
        /// </summary>
        /// <param name="MailNickname"></param>
        /// <returns></returns>
        Task<string> GetUser(string MailNickname);
        Task AddUser(string Name, string MailNickname);
        Task RemoveUser(string MailNickname);

        /// <summary>
        /// get users as json list
        /// </summary>
        /// <returns></returns>
        Task<string> GetUsers();
    }
    
}