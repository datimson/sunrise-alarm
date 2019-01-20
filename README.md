# sunrise-alarm
A sunrise alarm for the Raspberry Pi 3 Model B+ using a strip of RGB LEDs

"Error initializing the Gpio driver"
Expose the /dev/gpiomem device to the container at runtime
`docker run --device /dev/gpiomem -d deantimson/sunrise-alarm:latest`