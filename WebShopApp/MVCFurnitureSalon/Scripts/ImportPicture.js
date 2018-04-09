function SetImage() {
    var File1 = document.getElementById("File1");
    var img = document.getElementById("img");
    if (File1.value == "" || File1.value == null) {

        img.src = 'pic_bulbon.gif';
    }
    if (File1.files.length > 0 && File1.files[0].type.match(/image.*/)) {

        var imageFile = File1.files[0];
        var reader = new FileReader();

        reader.readAsDataURL(imageFile);

        reader.onload = function () {
            img.src = reader.result;
        }
    }
}