$(document).ready(function () {



    $.ajax({
        url: "../Operation/GetFoodBeveragesList",
        type: "POST",
        datatype: "json",
        data: null
    }).done(function (data) {
        $('#Restaurants_Food_List').empty();
        var Options = '';
        for (i = 0; i < data.length; i++) {
            //Options += '<div class="col-md-3 col-lg-3"><section class="panel"><div class="pro-img-box"><img src="../Images/fried_rice.jpg" alt="" /><a href="#" onclick="AddtoCart(' + data[i].Name + ',' + data[i].Price + ');" class="adtocart"><i class="fa fa-shopping-cart"></i></a></div><div class="panel-body text-center"><h4><a href="#" class="pro-title" id="' + data[i].ID + '">' + data[i].Name + '</a></h4><p class="price"> Rs: ' + data[i].Price + '</p></div></section></div>';
            Options += '<div class="col-md-3 col-lg-3"><section class="panel"><div class="pro-img-box"><img src="../Images/' + data[i].Name + '.jpg" alt="" /><a class="adtocart" href="javascript:AddtoCartTo('+ data[i].Name +','+ data[i].Price +');"><i class="fa fa-shopping-cart"></i></a></div><div class="panel-body text-center"><div class="item_name_res" id="' + data[i].Name + '"></div><h4>' + data[i].Name + '</h4></div><p class="price"> Rs: ' + data[i].Price + '</p></div></section></div>';
        }
        $('#Restaurants_Food_List').append(Options);
    });
});

//<button class="adtocart"><i class="fa fa-shopping-cart"></i></button>

var x = [];
  var CartData = [];
function AddtoCartTo(item, Price) {
  
    var valueToPush = [];

    CartData.push({ "productitem": item.id, "price": Price });
    console.log(CartData);
    BindTableToArray();
}


function BindTableToArray() {
     var Options = '';
    for (i = 0; i < CartData.length; i++) {
        //Options += '<div class="col-md-3 col-lg-3"><section class="panel"><div class="pro-img-box"><img src="../Images/fried_rice.jpg" alt="" /><a href="#" onclick="AddtoCart(' + data[i].Name + ',' + data[i].Price + ');" class="adtocart"><i class="fa fa-shopping-cart"></i></a></div><div class="panel-body text-center"><h4><a href="#" class="pro-title" id="' + data[i].ID + '">' + data[i].Name + '</a></h4><p class="price"> Rs: ' + data[i].Price + '</p></div></section></div>';
        Options += ' <tr><th>'+CartData[i]["product"]+'</th><th>'+CartData[i]["price"]+'</th></tr>';
    }
    $('#CartTableTemp').append(Options);
}


//const cards = document.querySelectorAll('.item_name_res');
//const cart = document.getElementById('cart');
//const totalElement = document.getElementById('total');
//const selectedItems = {};


//function handleCardClick(event) {
//    const card = event.currentTarget;
//    const itemId = card.id;
//    const itemName = card.querySelector('h4').textContent;
//    const itemPrice = parseFloat(card.querySelector('.price').textContent);

//    if (selectedItems[itemId]) {
//        selectedItems[itemId].count++;
//    } else {
//        selectedItems[itemId] = {
//            name: itemName,
//            price: itemPrice,
//            count: 1,
//        };
//    }

//    updateCart();
//}

//function updateCart() {
//    cart.innerHTML = '';
//    let total = 0;

//    for (const itemId in selectedItems) {
//        const item = selectedItems[itemId];
//        const listItem = document.createElement('li');
//        const quantityContainer = document.createElement('div');
//        const quantityText = document.createElement('span');
//        const addButton = document.createElement('button');
//        const subtractButton = document.createElement('button');

//        addButton.textContent = '+';
//        subtractButton.textContent = '-';

//        quantityText.textContent = item.count;

//        addButton.addEventListener('click', () => {
//            addItem(itemId);
//        });

//        subtractButton.addEventListener('click', () => {
//            removeItem(itemId);
//        });

//        const hr = document.createElement('hr');

//        quantityContainer.appendChild(subtractButton);
//        quantityContainer.appendChild(quantityText);
//        quantityContainer.appendChild(addButton);
//        quantityContainer.appendChild(hr);

//        listItem.textContent = `${item.name} - $${item.price * item.count}`;
//        listItem.appendChild(quantityContainer);
//        cart.appendChild(listItem);

//        total += item.price * item.count;
//    }

//    totalElement.textContent = `Общая сумма: $${total.toFixed(2)}`;
//}

//function addItem(itemId) {
//    if (selectedItems[itemId]) {
//        selectedItems[itemId].count++;
//    }
//    updateCart();
//}

//function removeItem(itemId) {
//    if (selectedItems[itemId]) {
//        selectedItems[itemId].count--;
//        if (selectedItems[itemId].count <= 0) {
//            delete selectedItems[itemId];
//        }
//    }
//    updateCart();
//}

//cards.forEach((card) => {
//    card.addEventListener('click', handleCardClick);
//});