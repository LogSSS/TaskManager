# Use a base image
FROM node:20-alpine

# Set the working directory
WORKDIR /app

# Copy the project files to the container
COPY . /app

# Install dependencies
RUN npm install -g @angular/cli

# Build the Angular app
RUN npm install

# Expose the necessary ports
EXPOSE 4200

# Define the command to run the application
CMD ["ng", "serve", "--host", "0.0.0.0"]