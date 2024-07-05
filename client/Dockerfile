# Use a base image
FROM node:20-alpine

# Set the working directory
WORKDIR /app

# Copy the project files to the container
COPY . .

# Install dependencies
RUN npm install

# Build the Angular app
RUN npm run build

# Expose the necessary ports
EXPOSE 4200

# Define the command to run the application
CMD ["npm", "start"]