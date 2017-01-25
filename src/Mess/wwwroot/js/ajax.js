class Ajax {
    var request = new XMLHttpRequest()
    var _data = {}
    var _contentType = null

    function get(url) {
        ajax('GET', url, json)
        return this
    }
    function post(url) {
        ajax('POST', url, json)
        return this
    }
    function put(url) {
        ajax('PUT', url)
        return this
    }
    function delete(url) {
        ajax('DELETE', url)
        return this
    }

    function header(name, value) {
        request.setRequestHeader(name, value)
        return this
    }
    // application/json
    function contentType(_contentType) {
        return this.header('Content-Type', _contentType)
    }
    // json, xml
    function data(__data) {
        _data = __data
        return this
    }
    function send(data) {
        _data = data == undefined ? _data : data
        request.send(_data)
        // todo: doesn't work since it's not synchronous
        return new Response(request.status, request.response)
    }

    function ajax(method, url, json) {
        request.open(method, url, true)
        request.onreadystatechange = function () {
            if (request.readyState != 4 || request.status != 200) {
                console.log('ajax error ' + url)
                return
            }
            console.log('ajax succeeded ' + url)
        }
    }
    //var res = get(url)
    //    .header('token', 'abcdefgh')
    //    .contentType('application/json')
    //    .accept('application/json')
    //    .data({})
    //    .send()
    //if (res.failed)
    //    return
    //var posts = res.body
}

class Response {
    constructor(statusNumber, body) {
        this.status = {
            "number": statusNumber,
            "text": STATUS[statusNumber.ToString()]
        }
        this.body = body
        this.succeeded = statusNumber >= 200 && statusNumber < 300
        this.failed = !this.succeeded
    }
    var STATUS = {
        "200": "OK",
        "201": "Created",
        "204": "No Content",
        "400": "Bad Request",
        "401": "Unauthorized",
        "403": "Forbidden",
        "404": "Not Found",
        "405": "Method Not Allowed",
        "500": "Server Error",
        "503": "Service Unavailable"
    }
}