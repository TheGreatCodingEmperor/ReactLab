# bin/bash
dotnet ef dbcontext scaffold "server=127.0.0.1;port=3307;user id=root;password=70400845;database=ReactLab;charset=utf8;" Pomelo.EntityFrameworkCore.MySql -o EFCore -t store