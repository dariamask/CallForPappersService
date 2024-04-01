Добрый день!

1. Для сборки докер-образа введите в командной строке команду (в папке солюшена):

build -fCallForPappersService/Dockerfile -t service .

2. Для запуска контейнера введите:

docker run -d -p80:80 service
