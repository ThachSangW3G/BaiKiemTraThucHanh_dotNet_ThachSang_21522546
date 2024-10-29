async function callAPI() {
    try {
        // URL của API cần gọi
        const response = await fetch("https://localhost:7146/api/Category", {
            method: "GET",
            headers: {
                "Accept": "text/plain"
            }
        });

        // Kiểm tra phản hồi từ API
        if (!response.ok) {
            throw new Error(`Lỗi: ${response.status}`);
        }

        // Lấy dữ liệu từ API và chuyển đổi sang JSON
        const data = await response.json();

        console.log(data)

        // Gọi hàm để đổ dữ liệu vào danh sách thẻ li
        displayData(data);
    } catch (error) {
        console.error("Lỗi khi gọi API:", error);
    }
}

function displayData(data) {
    // Lấy phần tử ul có id là 'object-list'
    const listElement = document.getElementById("object-list");

    // Xóa nội dung cũ trong danh sách (nếu có)
    listElement.innerHTML = '';  

    // Lặp qua mỗi đối tượng trong dữ liệu và tạo thẻ li
    data.forEach(item => {
        // Tạo thẻ li cho mỗi đối tượng
        const listItem = document.createElement("li");
        listItem.textContent = `${item.name}`;

        // Thêm thẻ li vào ul
        listElement.appendChild(listItem);
    });
}



async function loadCategories() {
    try {
        const response = await fetch("https://localhost:7146/api/Category", {
            method: "GET",
            headers: {
                "Accept": "text/plain"
            }
        });

        if (!response.ok) {
            throw new Error(`Lỗi: ${response.status}`);
        }

        const data = await response.json();
        const categoriesContainer = document.getElementById("categoriesContainer");
        const featuredList = document.getElementById("featuredList");

        if (!categoriesContainer) {
            console.error("Không tìm thấy phần tử với ID 'categoriesContainer'");
            return;
        }

        if (!featuredList) {
            console.error("Không tìm thấy phần tử với ID 'featuredList'");
            return;
        }

        featuredList.innerHTML = `
        <li class="active" data-filter="*">All</li>
        `;


        data.forEach(category => {
            const li = document.createElement("li");
            li.setAttribute("data-filter", `.category_${category.categoryId}`);
            li.textContent = category.name;
            featuredList.appendChild(li);
        });

        // Tạo HTML từ dữ liệu API
        let categoriesHTML = "";
        data.forEach(category => {
            categoriesHTML += `
                <div class="col-lg-3">
                    <div class="categories__item set-bg" style="background-image: url('${category.imageUrl}')">
                        <h5><a href="#">${category.name}</a></h5>
                    </div>
                </div>
            `;
        });

        // Gán HTML vào container
        categoriesContainer.innerHTML = categoriesHTML;

        // Khởi tạo lại carousel
        // $('.categories__slider').owlCarousel('refresh');

    } catch (error) {
        console.error("Lỗi khi gọi API:", error);
    }
}


async function loadProducts() {
    try {
        const response = await fetch("https://localhost:7146/api/Product", {
            method: "GET",
            headers: {
                "Accept": "application/json"
            }
        });

        if (!response.ok) {
            throw new Error(`Lỗi: ${response.status}`);
        }

        const products = await response.json();
        const featuredContainer = document.getElementById("featuredContainer");

        if (!featuredContainer) {
            console.error("Không tìm thấy phần tử với ID 'featuredContainer'");
            return;
        }


        console.log(products)

        // Xóa nội dung cũ trong container (nếu cần)
        featuredContainer.innerHTML = "";

        // Duyệt qua từng sản phẩm và tạo HTML động
        products.forEach(product => {
            // Tạo chuỗi các danh mục từ mảng categories
          

            // Tạo HTML cho mỗi sản phẩm
            const productHTML = `
           
                <div class="col-lg-3 col-md-4 col-sm-6 mix category_${product.categoryId}">
                  
                    <div class="featured__item" onClick="goToProductPage()">
                        <div class="featured__item__pic set-bg" style="background-image: url('${product.imageUrl}')">
                            <ul class="featured__item__pic__hover">
                                <li><a href="#"><i class="fa fa-heart"></i></a></li>
                                <li><a href="#"><i class="fa fa-retweet"></i></a></li>
                                <li><a href="#"><i class="fa fa-shopping-cart"></i></a></li>
                            </ul>
                        </div>
                        <div class="featured__item__text">
                            <h6><a href="#">${product.name}</a></h6>
                            <h5>$${product.price.toFixed(2)}</h5>
                        </div>
                    </div>

                    
                </div>
              
            `;

            // Thêm HTML vào container
            featuredContainer.innerHTML += productHTML;
        });

        // Khởi tạo hoặc cập nhật carousel hoặc thư viện filter (nếu có)
        //$('.featured__filter').owlCarousel('refresh');

    } catch (error) {
        console.error("Lỗi khi gọi API:", error);
    }
}


function goToProductPage() {
    const productId = 1;  // ID của sản phẩm
    const productName = "Bananas";  // Tên sản phẩm
    window.location.href = `./shop-details.html?id=${productId}&name=${encodeURIComponent(productName)}`;
}

document.addEventListener("DOMContentLoaded", loadCategories);
document.addEventListener("DOMContentLoaded", loadProducts);
// Gọi hàm callAPI khi trang tải xong
callAPI();