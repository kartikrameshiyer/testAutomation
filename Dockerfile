# Use the official .NET SDK image as the base
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Install Chrome and ChromeDriver
RUN apt-get update && apt-get install -y wget gnupg2 apt-transport-https unzip
RUN wget -q -O - https://dl-ssl.google.com/linux/linux_signing_key.pub | apt-key add -
RUN sh -c 'echo "deb [arch=amd64] http://dl.google.com/linux/chrome/deb/ stable main" >> /etc/apt/sources.list.d/google.list'
RUN apt-get update && apt-get install -y google-chrome-stable

# Download and install the latest stable ChromeDriver
RUN LATEST_VERSION=$(curl -sS https://chromedriver.storage.googleapis.com/LATEST_RELEASE) && \
    wget -q https://chromedriver.storage.googleapis.com/$LATEST_VERSION/chromedriver_linux64.zip && \
    unzip chromedriver_linux64.zip && \
    mv chromedriver /usr/local/bin/chromedriver && \
    rm chromedriver_linux64.zip

# Set environment variables for Chrome and ChromeDriver
ENV CHROME_BIN=/usr/bin/google-chrome
ENV CHROME_DRIVER=/usr/local/bin/chromedriver

# Set the working directory
WORKDIR /app

# Copy all the project files before running dotnet restore
COPY . /app

# Restore the dependencies
RUN dotnet restore

# Build the project
RUN dotnet build --configuration Release

# Accept test category to run different test suites in containers
ARG TEST_CATEGORY

# Run SpecFlow tests using NUnit with filter for test categories
ENTRYPOINT ["dotnet", "test", "--filter", "FullyQualifiedName~%TEST_CATEGORY%"]
