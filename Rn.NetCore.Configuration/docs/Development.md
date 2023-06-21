# Development
`WIP`: Running things locally may make it easier to develop.

## Docker Containers
More information can be found [here](https://hub.docker.com/_/mariadb)...

You can run the container using the following command from the `./docker` directory:

```shell
docker-compose up
```

This will expose MariaDB on port `3306` along with executing all the scripts located under the `./docker/init/` directory - seeding some sample data to work with should you need it.
