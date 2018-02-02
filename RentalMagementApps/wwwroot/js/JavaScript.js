$(document).ready(function () {
    $.fn.serializeData = function (flag) {
        var o = {};
        var a = this.serializeArray();
        console.log(flag);
        if (flag == false) {
            console.log('zzz');
            return a;
        }
        $.each(a, function () {
            if (o[this.name]) {
                if (!o[this.name].push) {
                    o[this.name] = [o[this.name]];
                }
                o[this.name].push(this.value || '');
            } else {
                o[this.name] = this.value || '';
            }
        });
        return JSON.stringify(o);
    };
    $('.submit-button').click(function (e) {
        e.preventDefault();
        $form = $(this).closest('form');
        $form.find('.error_message').html(''); 
        var data = $form.serializeData($(this).data('form-type') == 'api');
        $method = 'POST';
        if ($form.attr('enctype')) {
            var formEnctype = $form.attr('enctype')
        }
        else {
            var formEnctype = 'application/json; charset=utf-8';
            if ($form.attr('method')) {
                $method = $form.attr('method');
            }
        }
        
        $.ajax({
            url: $form.attr('action'),
            method: $method,
            dataType: 'JSON',
            data: data,
            contentType: formEnctype,
            success: function (data) {
                if (data.status) {
                    if (data.message) {
                        alert(data.message);
                    }
                    if (data.next_page) {
                        window.location.href = data.next_page;
                    }
                }
                else if (data.message) {
                    if (data.need_reload) {
                        alert(data.message);
                        window.location.reload();
                    }
                    else {
                        $form.find('.error_message').html("<li>" + data.message + "</li>");
                    }
                    
                }
                
            },
            error: function (data) {
                $error_msg = '';
                $.each(data.responseJSON, function (attr, errorMessages) {
                    $.each(errorMessages, function () {
                        $error_msg = $error_msg + '<li>' + this + '</li>';
                    });
                });
                $form.find('.error_message').html($error_msg);
            }
        });
    });

    $('body').on('click','.delete',function (e) {
        e.preventDefault();
        var r = confirm("Anda yakin menghapus?");
        if (r) {
            $url = $(this).attr('href');
            $.ajax({
                url: $url,
                method: 'delete',
                dataType: 'JSON',
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    if (data.status) {
                        if (data.next_page) {
                            window.location.href = data.next_page;
                        }
                        else if (data.need_reload) {
                            window.location.reload();
                        }
                    }
                    else if (data.message) {
                        alert(data.message);
                    }
                },
                error: function (data) {
                    $error_msg = '';
                    $.each(data.responseJSON, function (attr, errorMessages) {
                        $.each(errorMessages, function () {
                            $error_msg = $error_msg + this;
                        });
                    });
                    alert($error_msg);
                }
            });
        }
    });
});