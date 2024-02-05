# Stage 1: Build the React frontend
FROM node:16 As react-build

WORKDIR /app

COPY client/package.json client/package-lock.json ./

RUN npm install

COPY client ./

RUN npm run build

# Stage 2: Build the .NET Core backend
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS backend-build

WORKDIR /app

# Copy the .NET Core project and restore dependencies
COPY server/*.csproj ./
RUN dotnet restor

# Copy the backend source code
COPY . ./
RUN dotnet publish -c Release -o out

# Stage 3: Build the final image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app

COPY --from=backend-build /app/out .

# Copy the built frontend from the previous stage
COPY --from=react-build /app/build ./wwwroot

# Expose port 80 to the outside world
EXPOSE 80

# Define the entry point for the container
ENTRYPOINT ["dotnet", "server.dll"]