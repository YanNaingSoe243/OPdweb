let video = null;
let canvas = null;
let context = null;
let streaming = false;
let width = 480;    // We will scale the photo width to this.
let height = 0;     // This will be computed based on the input stream
let filter = 'sepia(1)';
export function onStart(options) {
    video = document.getElementById(options.videoID);
    canvas = document.getElementById(options.canvasID);
    context = canvas.getContext('2d');
    width = options.width;
    //filter = options.filter;
    navigator.mediaDevices.getUserMedia({ video: true, audio: false })
        .then(function (stream) {
            video.srcObject = stream;
            video.play();
        })
        .catch(function (err) {
            console.log("An error occurred: " + err);
        });
    video.addEventListener('canplay', function () {
        if (!streaming) {
            height = video.videoHeight / (video.videoWidth / width);
            if (isNaN(height)) {
                height = width / (4 / 3);
            }
            video.setAttribute('width', width);
            video.setAttribute('height', height);
            canvas.setAttribute('width', width);
            canvas.setAttribute('height', height);
            streaming = true;
        }
    }, false);
    video.addEventListener("play", function () {
        console.log('play');
        timercallback();
    }, false);
}
function timercallback() {
    if (video.paused || video.ended) {
        return;
    }
    computeFrame();
    setTimeout(function () {
        timercallback();
    }, 0);
}
function computeFrame() {
    context.drawImage(video,0,0, width, height);
    //context.filter = filter;
}

export function getFrame(options, dotNetHelper) {
    video = document.getElementById(options.videoID);
    canvas = document.getElementById(options.canvasID);
    canvas.getContext('2d').drawImage(video,0,0, 480,500);
    let dataUrl = canvas.toDataURL("image/jpeg");
    dotNetHelper.invokeMethodAsync('ProcessImage', dataUrl);
}
export function sayHi(name, dotNetHelper) {
   
    var btns = name.getElementsByClassName("opdbottom");

 
    name.addEventListener("scroll", function () {
        var diff = difference((this.scrollTop + this.clientHeight), (this.scrollHeight));

        
        if (diff < 2) {
            dotNetHelper.invokeMethodAsync('ScrollDataLoad', "true");
           
        }
        
    });
  
        
 
    
  
}

var printer = null;
export function PrintQRCode(print) {
    var mywindow = window.open('', '', 'height=500, width=900');
    //mywindow.document.write('<html><head><title></title>');
    //mywindow.document.write('</head><body>');   
    mywindow.document.write('<img src=data:image/png;base64,'+print+'>');
   /* mywindow.document.write('</body></html>');*/
    mywindow.document.close();// necessary for IE >= 10
    mywindow.focus(); // necessary for IE >= 10*/   
    mywindow.print();
   /* mywindow.close();*/
    
}
function difference(first, sec) {
    return Math.abs(first - sec);
}

export function scrollEvent(itembar) {
    alert(`hello ${itembar}!`);
    //var btns = itembar.getElementsByClassName("opdbottom");
    //btns.addEventListener("scroll", function () {
    //    var diff = difference((this.scrollTop + this.clientHeight), (this.scrollHeight));

    //    if (diff < 5) {
    //        alert('Scroll Ends Here');
    //    }
    //});
   
}