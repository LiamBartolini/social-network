function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader()

        reader.onload = function(e) {
            document.getElementById('realPath')
                .setAttribute('value', e.target.result)
        }

        reader.readAsDataURL(input.files[0])
    }
}