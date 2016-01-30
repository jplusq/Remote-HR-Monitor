var uwp = require("uwp");
var awsIot = require('aws-iot-device-sdk');
uwp.projectNamespace("Windows");

var gpioController = Windows.Devices.Gpio.GpioController.getDefault();
var pin = gpioController.openPin(26);
pin.setDriveMode(Windows.Devices.Gpio.GpioPinDriveMode.output);
pin.write(Windows.Devices.Gpio.GpioPinValue.low);

var device = awsIot.device({
    keyPath: 'c:/Data/Users/DefaultAccount/AppData/Local/Packages/HRAlarm_x98x5gd4ncns2/LocalState/awsCerts/28ea7011c3-private.pem.key',
    certPath: 'c:/Data/Users/DefaultAccount/AppData/Local/Packages/HRAlarm_x98x5gd4ncns2/LocalState/awsCerts/28ea7011c3-certificate.pem.crt',
    caPath: 'c:/Data/Users/DefaultAccount/AppData/Local/Packages/HRAlarm_x98x5gd4ncns2/LocalState/awsCerts/aws-iot-rootCA.crt',
    clientId: 'Qin',
    region: 'us-east-1'
});

//
// Device is an instance returned by mqtt.Client(), see mqtt.js for full
// documentation.
//
device
  .on('connect', function () {
    console.log('connect');
    device.subscribe('HRAlarm/on');
    device.subscribe('HRAlarm/off');
    device.publish('$aws/things/LED1/shadow/update', JSON.stringify({ ready: true }));
});

device
  .on('message', function (topic, payload) {
    console.log('message', topic);
    if (topic == 'HRAlarm/on') {
        pin.write(Windows.Devices.Gpio.GpioPinValue.high);
    } else if (topic == 'HRAlarm/off'){
        pin.write(Windows.Devices.Gpio.GpioPinValue.low);
    }
});

uwp.close();
