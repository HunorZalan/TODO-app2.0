// My web app`s Firebase configuration
var firebaseConfig = {
    apiKey: "AIzaSyDRs4q6iC5ZC-2ByTcM-TaAmT_iEixYcKA",
    authDomain: "database-651ea.firebaseapp.com",
    databaseURL: "https://database-651ea.firebaseio.com",
    projectId: "database-651ea",
    storageBucket: "database-651ea.appspot.com",
    messagingSenderId: "302308004819",
    appId: "1:302308004819:web:eae8b75637681777da1526",
    measurementId: "G-7HZR15SRXJ"
};
// Initialize Firebase
firebase.initializeApp(firebaseConfig);

// My alert
function CustomAlert(){
    this.render = function(dialog){
        var dialogoverlay = document.getElementById('dialogoverlay');
        var dialogbox = document.getElementById('dialogbox');
        dialogoverlay.style.display = "block";
        dialogbox.style.display = "block";
        document.getElementById('dialogboxhead').innerHTML = "Today's program: <span id=\"pipe\" class=\"fa fa-check\"></span><\span>";
        document.getElementById('dialogboxbody').innerHTML = "<span>" + dialog + "</span>";
        document.getElementById('dialogboxfoot').innerHTML = '<button id="close" onclick="Alert.ok()">OK</button>';
    }
	this.ok = function(){
		document.getElementById('dialogbox').style.display = "none";
		document.getElementById('dialogoverlay').style.display = "none";
	}
}
var Alert = new CustomAlert();

function add_todo(){
    //console.log("add_todo");
    input_box = document.getElementById("input_box");
    var input_date = document.getElementById("input_date");

    if (input_box.value.length != 0 && input_date.value.length != 0){ // not empty
        var key = firebase.database().ref().child("unfinished_ToDo").push().key;
        //console.log(key);
        var todo = {
            Title: input_box.value,
            Date: input_date.value.replace("T", " "),
            Key: key
        };

        var updates = {};
        updates["/unfinished_ToDo/" + key] = todo;
        firebase.database().ref().update(updates); 
        create_unfinished_ToDo();
        var a = document.getElementById("input_box");
        a.value = a.defaultValue;
        var b = document.getElementById("input_date");
        b.value = b.defaultValue;
    }
    else{
        alert("Incorrect data!");
    }
}

// Date
var today = new Date();
//console.log(today);
var dd = String(today.getDate()).padStart(2, '0');
var mm = String(today.getMonth() + 1).padStart(2, '0');
var yyyy = today.getFullYear();
var dd1 = String(today.getDate());
var mm1 = String(today.getMonth() + 1);
var hour = today.getHours();
var minute = today.getMinutes();
var today0 = yyyy + '-' + mm + '-' + dd;
var today1 = mm1 + '/' + dd1 + '/' + yyyy;
today = yyyy + '-' + mm + '-' + dd + ' ' + hour + ':' + minute;
//console.log(today);

function create_unfinished_ToDo(){
    unfinished_ToDo_container = document.getElementsByClassName("container")[0];
    expired_ToDo_container = document.getElementsByClassName("container")[2];
    unfinished_ToDo_container.innerHTML = "";
    expired_ToDo_container.innerHTML = "";

    todo_arrayf = [];
    firebase.database().ref("unfinished_ToDo").once('value', function(snapshot){
        snapshot.forEach(function(childSnapshot){
            //var childKey = childSnapshot.key;
            var childData = childSnapshot.val();
            //console.log(childKey+": "+childData);
            todo_arrayf.push(Object.values(childData));
        });
        //console.log(todo_arrayf.length);
        assigment = "";
        for (var i, i = 0; i < todo_arrayf.length; ++i){
            //console.log(todo_array[i]);
            todo_date = todo_arrayf[i][0];
            todo_key = todo_arrayf[i][1];
            todo_title = todo_arrayf[i][2];

            if (todo_date[1] == '/' || todo_date[2] == '/'){
                if (todo_date[1] == '/'){
                    m = todo_date.substring(0, 1);
                    if (todo_date[3] == '/'){
                        d = todo_date.substring(2, 3);
                        y = todo_date.substring(4, 9);
                    }
                    else{
                        d = todo_date.substring(2, 4);
                        y = todo_date.substring(5, 10);
                    }
                }
                else{
                    m = todo_date.substring(0, 2);
                    if (todo_date[4] == '/'){
                        d = todo_date.substring(3, 4);
                        y = todo_date.substring(5, 10);
                    }
                    else{
                        d = todo_date.substring(3, 5);
                        y = todo_date.substring(6, 11);
                    }
                }
            }
            else{
                mytodo_date = todo_date.substring(0, todo_date.length - 6);
                y = todo_date.substring(0, 4);
                m = todo_date.substring(5, 7);
                d = todo_date.substring(8, 11);
            }

            if (mytodo_date == today0 || mytodo_date == today1){
                //console.log(todo_title);
                assigment += todo_title;
                assigment += ", ";
            }
            
            if (parseInt(y) >= yyyy && parseInt(m) >= mm && parseInt(d) >= dd){
                todo_container = document.createElement('div');
                todo_container.setAttribute("class", "data_container");
                todo_container.setAttribute("data-key", todo_key);
    
                // data
                todo_data = document.createElement('div');
                todo_data.setAttribute('id', 'data');
    
                title = document.createElement('p');
                title.setAttribute('id', 'title');
                title.setAttribute('contenteditable', false);
                title.innerHTML = todo_title;
    
                date = document.createElement('p');
                date.setAttribute('id', 'date');
                date.setAttribute('contenteditable', false);
                date.innerHTML = todo_date;
    
                // tools
                todo_tool = document.createElement('div');
                todo_tool.setAttribute('id', 'tool')
    
                todo_done_button = document.createElement('button');
                todo_done_button.setAttribute('id', 'done_button');
                todo_done_button.setAttribute('onclick', "todo_done(this.parentElement.parentElement, this.parentElement)");
                fa_done = document.createElement('i');
                fa_done.setAttribute('class', 'fa fa-plus');
    
                todo_edit_button = document.createElement('button');
                todo_edit_button.setAttribute('id', 'edit_button');
                todo_edit_button.setAttribute('onclick', "todo_edit(this.parentElement.parentElement, this)");
                fa_edit = document.createElement('i');
                fa_edit.setAttribute('class', 'fa fa-pencil');
    
                todo_delete_button = document.createElement('button');
                todo_delete_button.setAttribute('id', 'delete_button');
                todo_delete_button.setAttribute('onclick', "todo_delete(this.parentElement.parentElement, 0)");
                fa_delete = document.createElement('i');
                fa_delete.setAttribute('class', 'fa fa-trash');

                // show 
                unfinished_ToDo_container.append(todo_container);
                todo_container.append(todo_data);
                todo_data.append(title);
                todo_data.append(date);
    
                todo_container.append(todo_tool);
                todo_tool.append(todo_done_button);
                todo_done_button.append(fa_done);
                todo_tool.append(todo_edit_button);
                todo_edit_button.append(fa_edit);
                todo_tool.append(todo_delete_button);
                todo_delete_button.append(fa_delete);
            }
            else{
                todo_container = document.createElement('div');
                todo_container.setAttribute("class", "data_container");
                todo_container.setAttribute("data-key", todo_key);

                // data
                todo_data = document.createElement('div');
                todo_data.setAttribute('id', 'data');

                title = document.createElement('p');
                title.setAttribute('id', 'title');
                title.setAttribute('contenteditable', false);
                title.innerHTML = todo_title;

                date = document.createElement('p');
                date.setAttribute('id', 'date');
                date.setAttribute('contenteditable', false);
                date.innerHTML = todo_date;

                todo_tool = document.createElement('div');
                todo_tool.setAttribute('id', 'tool')

                todo_done_button = document.createElement('button');
                todo_done_button.setAttribute('id', 'done_button');
                todo_done_button.setAttribute('onclick', "todo_done(this.parentElement.parentElement, this.parentElement)");
                fa_done = document.createElement('i');
                fa_done.setAttribute('class', 'fa fa-plus');

                todo_delete_button = document.createElement('button');
                todo_delete_button.setAttribute('id', 'delete_button');
                todo_delete_button.setAttribute('onclick', "todo_delete(this.parentElement.parentElement, 0)");
                fa_delete = document.createElement('i');
                fa_delete.setAttribute('class', 'fa fa-trash');

                // show
                expired_ToDo_container.append(todo_container);
                todo_container.append(todo_data);
                todo_data.append(title);
                todo_data.append(date);
                
                todo_container.append(todo_tool);
                todo_tool.append(todo_done_button);
                todo_done_button.append(fa_done);
                todo_tool.append(todo_delete_button);
                todo_delete_button.append(fa_delete);
            }
        }
        if (assigment != ""){
            assigment = assigment.substring(0, assigment.length - 2);
            
            alert("Today's program: " + assigment);
            //Alert.render(assigment)
        }
    });
}

function create_finished_ToDo(){
    finished_ToDo_container = document.getElementsByClassName("container")[1];
    expired_ToDo_container = document.getElementsByClassName("container")[2];
    finished_ToDo_container.innerHTML = "";
    expired_ToDo_container.innerHTML = "";

    todo_array = [];
    firebase.database().ref("finished_ToDo").once('value', function(snapshot){
        snapshot.forEach(function(childSnapshot){
            //var childKey = childSnapshot.key;
            var childData = childSnapshot.val();
            todo_array.push(Object.values(childData));
        });
        //console.log(todo_array.length);
        for (var i, i = 0; i < todo_array.length; ++i){
            //console.log(todo_array[i]);
            todo_date = todo_array[i][0];
            todo_key = todo_array[i][1];
            todo_title = todo_array[i][2];

            todo_container = document.createElement('div');
            todo_container.setAttribute("class", "data_container");
            todo_container.setAttribute("data-key", todo_key);

            // data
            todo_data = document.createElement('div');
            todo_data.setAttribute('id', 'data');

            title = document.createElement('p');
            title.setAttribute('id', 'title');
            title.setAttribute('contenteditable', false);
            title.innerHTML = todo_title;

            date = document.createElement('p');
            date.setAttribute('id', 'date');
            date.setAttribute('contenteditable', false);
            date.innerHTML = todo_date;

            // tools
            todo_tool = document.createElement('div');
            todo_tool.setAttribute('id', 'tool')

            todo_minus_button = document.createElement('button');
            todo_minus_button.setAttribute('id', 'minus_button');
            todo_minus_button.setAttribute('onclick', "todo_minus(this.parentElement.parentElement, this.parentElement)");
            fa_minus = document.createElement('i');
            fa_minus.setAttribute('class', 'fa fa-minus');

            todo_delete_button = document.createElement('button');
            todo_delete_button.setAttribute('id', 'delete_button');
            todo_delete_button.setAttribute('onclick', "todo_delete(this.parentElement.parentElement, 1)");
            fa_delete = document.createElement('i');
            fa_delete.setAttribute('class', 'fa fa-trash');

            // show
            finished_ToDo_container.append(todo_container);
            todo_container.append(todo_data);
            todo_data.append(title);
            todo_data.append(date);

            todo_container.append(todo_tool);
            todo_tool.append(todo_minus_button);
            todo_minus_button.append(fa_minus);
            todo_tool.append(todo_delete_button);
            todo_delete_button.append(fa_delete);
        }
    });
}

function todo_done(todo, todo_tool){
    //console.log("todo_done");
    finish_todo_container = document.getElementsByClassName("container")[1];
    todo.removeChild(todo_tool);

    finish_todo_container.append(todo);

    var key = todo.getAttribute("data-key");
    var todo_obj = {
        title: todo.childNodes[0].childNodes[0].innerHTML,
        date: todo.childNodes[0].childNodes[1].innerHTML,
        key: key
    };

    var updates = {};
    updates["/finished_ToDo/" + key] = todo_obj;
    firebase.database().ref().update(updates); 

    // delete our ToDo from unfinished
    todo_delete(todo, 0);
    create_finished_ToDo();
    create_unfinished_ToDo();
}

function todo_minus(todo, todo_tool){
    //console.log("todo_minus");
    unfinish_todo_container = document.getElementsByClassName("container")[0];
    todo.removeChild(todo_tool);

    unfinish_todo_container.append(todo);

    var key = todo.getAttribute("data-key");
    var todo_obj = {
        title: todo.childNodes[0].childNodes[0].innerHTML,
        date: todo.childNodes[0].childNodes[1].innerHTML,
        key: key
    };

    var updates = {};
    updates["/unfinished_ToDo/" + key] = todo_obj;
    firebase.database().ref().update(updates); 

    // delete our ToDo from unfinished
    todo_delete(todo, 1);
    create_unfinished_ToDo();
}

function todo_edit(todo, edit_button){
    //console.log("todo_edit");
    /*edit_button.style.backgroundColor = "#ffed83" // yellow
    edit_button.style.color = "#fff" // white*/
    edit_button.setAttribute("id", "edit_button_editing");
    edit_button.setAttribute("onclick", "finish_edit(this.parentElement.parentElement, this)");

    title = todo.childNodes[0].childNodes[0];
    title.setAttribute("contenteditable", true);

    //date = todo.childNodes[0].childNodes[1];
    //date.setAttribute("contenteditable", true);
}

function finish_edit(todo, edit_button){
    /*edit_button.style.backgroundColor = "#fff" // white
    edit_button.style.color = "#000" // black*/
    edit_button.setAttribute("id", "edit_button");
    edit_button.setAttribute("onclick", "todo_edit(this.parentElement.parentElement, this)");

    title = todo.childNodes[0].childNodes[0];
    title.setAttribute("contenteditable", false);

    //date = todo.childNodes[0].childNodes[1];
    //date.setAttribute("contenteditable", false);

    // change in firebase to
    var key = todo.getAttribute("data-key");
    var todo_obj = {
        title: todo.childNodes[0].childNodes[0].innerHTML,
        date: todo.childNodes[0].childNodes[1].innerHTML,
        key: key
    };

    var updates = {};
    updates["/unfinished_ToDo/" + key] = todo_obj;
    firebase.database().ref().update(updates);
}

function todo_delete(todo, where){
    //console.log("todo_delete");
    key = todo.getAttribute("data-key");
    if (where == 0){
        todo_to_remove = firebase.database().ref("unfinished_ToDo/" + key);
    }
    else{
        todo_to_remove = firebase.database().ref("finished_ToDo/" + key);
    }
    console.log(where);
    todo_to_remove.remove();

    // remove from html view or whatever
    todo.remove();
}

// Current time
var months = ["January", "February", "March", "April", "May", "June", "July", "Augest", "September", "October", "November", "December"];
var week = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"];
var ids = ["dayname", "month", "daynum", "year", "hour", "minutes", "seconds", "period"];
function updateClock(){
    var now = new Date();
    var dname = now.getDay(), mo = now.getMonth(), dnum = now.getDate(), yr = now.getFullYear(), hou = now.getHours(), min = now.getMinutes(), sec = now.getSeconds(), pe = "AM";
    if (hou >= 12){
        pe = "PM";
    }
    if (hou == 0){
        hou = 12;
    }
    if (hou > 12){
        hou = hou - 12;
    }
    Number.prototype.pad = function(digits){
        for (var i = this.toString(); i.length < digits; i = 0 + i);
        return i;
    }
    var values = [week[dname], months[mo], dnum.pad(2), yr, hou.pad(2), min.pad(2), sec.pad(2), pe];
    for(var i = 0; i < ids.length; i++){
        document.getElementById(ids[i]).firstChild.nodeValue = values[i];
    }
}

function initClock(){
    updateClock();
    window.setInterval("updateClock()", 1);
}
