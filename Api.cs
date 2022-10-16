namespace APIApp
{
    public static class Api
    {
        public static void ConfigureApi(this WebApplication app)
        {
            //All of my API endpoints mapping
            app.MapGet("/users", getUsers);
            app.MapGet("/users/{id}", getUser);
            app.MapPost("/users/add", insertUser);
            app.MapPut("/users/update", updateUser);
            app.MapDelete("/users/delete/{id}", deleteUser);
        }

        private static async Task<IResult> getUsers(IUserData data)
        {
            try
            {
                return Results.Ok(await data.getUsers());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> getUser(int id, IUserData data)
        {
            try
            {
                var results = await data.getUser(id);
                if (results == null) return Results.NotFound();
                return Results.Ok(results);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> insertUser(UserModel user, IUserData data)
        {
            try
            {
                await data.insertUser(user);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> updateUser(UserModel user, IUserData data)
        {
            try
            {
                await data.updateUser(user);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> deleteUser(int id, IUserData data)
        {
            try
            {
                await data.deleteUser(id);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

    }
}
