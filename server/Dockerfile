FROM wordpress:php7.2

RUN apt update && apt install -y libmagickwand-dev curl git
RUN yes "" | pecl install imagick
RUN echo "extension=imagick.so" > /usr/local/etc/php/docker-php-ext-imagick.ini	
RUN docker-php-ext-enable imagick
RUN /etc/init.d/apache2 restart
WORKDIR /var/www/html/wp-content/plugins
RUN curl -O https://downloads.wordpress.org/plugin/pdf-image-generator.1.5.6.zip && unzip pdf-image-generator.1.5.6.zip && rm pdf-image-generator.1.5.6.zip
RUN curl -LOk https://github.com/WP-API/Basic-Auth/archive/master.zip && unzip master.zip && rm master.zip
RUN curl -O https://downloads.wordpress.org/plugin/oauth2-provider.3.4.5.zip && unzip oauth2-provider.3.4.5.zip && rm oauth2-provider.3.4.5.zip

