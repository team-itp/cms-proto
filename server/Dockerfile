FROM wordpress:php7.2

RUN apt update && apt install -y libmagickwand-dev
RUN yes "" | pecl install imagick
RUN echo "extension=imagick.so" > /usr/local/etc/php/docker-php-ext-imagick.ini	
RUN docker-php-ext-enable imagick
RUN /etc/init.d/apache2 restart

