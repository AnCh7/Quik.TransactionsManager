namespace Quik.TransactionsManager.Library.Models
{
	/// Файл представляет собой последовательность строк, каждая из которых содержит информацию по отдельной транзакции. 
	/// Параметры транзакции описываются в виде «НАЗВАНИЕ_ПАРАМЕТРА= значение_параметра» и разделяются символом «;».
	/// Замечание: Транзакция на ввод айсберг-заявки на ММВБ описывается в особом формате, приведенном в примере строк файла. 
	/// 
	/// Параметры и принимаемые ими значения:
	/// Команды снятия группы заявок по условию («KILL_ALL_ORDERS», «KILL_ALL_STOP_ORDERS», «KILL_ALL_NEG_DEALS», 
	/// «KILL_ALL_FUTURES_ORDERS») обрабатываются следующим образом:
	/// 
	/// Параметры «CLASSCODE», «TRANS_ID», «ACTION»,  «ACCOUNT» являются обязательными. 
	///  
	/// Возможные дополнительные параметры для команд снятия заявок по условию: 
	/// «KILL_ALL_ORDERS»: «SECCODE», «ACCOUNT», «OPERATION», «CLIENT_CODE», «COMMENT» 
	/// «KILL_ALL_STOP_ORDERS»: «SECCODE», «ACCOUNT», «OPERATION», «CLIENT_CODE», «COMMENT», «EXPIRY_DATE» 
	/// «KILL_ALL_NEG_DEALS»: «SECCODE», «ACCOUNT», «OPERATION», «CLIENT_CODE», «COMMENT», «PARTNER», «SETTLE_CODE» 
	/// «KILL_ALL_FUTURES_ORDERS»: «ACCOUNT», «OPERATION»
	/// Снятию подлежат заявки, соответствующие всем указанным в транзакции параметрам (логическое «И»).
	public class QuikInbound
	{
		/// <summary>
		///     Код класса, по которому выполняется транзакция, например EQBR.
		///     Обязательный параметр
		/// </summary>
		public string CLASSCODE { get; set; }

		/// <summary>
		///     Код инструмента, по которому выполняется транзакция, например SBER
		/// </summary>
		public string SECCODE { get; set; }

		/// <summary>
		///     Вид транзакции, имеющий одно из следующих значений:
		///     «NEW_ORDER» - новая заявка,
		///     «NEW_NEG_DEAL» - новая заявка на внебиржевую сделку,
		///     «NEW_REPO_NEG_DEAL» – новая заявка на сделку РЕПО,
		///     «NEW_EXT_REPO_NEG_DEAL» - новая заявка на сделку модифицированного РЕПО (РЕПО-М),
		///     «NEW_STOP_ORDER» - новая стоп-заявка,
		///     «KILL_ORDER» - снять заявку,
		///     «KILL_NEG_DEAL» - снять заявку на внебиржевую сделку или заявку на сделку РЕПО,
		///     «KILL_STOP_ORDER» - снять стоп-заявку,
		///     «KILL_ALL_ORDERS» – снять все заявки из торговой системы,
		///     «KILL_ALL_STOP_ORDERS» – снять все стоп-заявки,
		///     «KILL_ALL_NEG_DEALS» – снять все заявки на внебиржевые сделки и заявки на сделки РЕПО,
		///     «KILL_ALL_FUTURES_ORDERS» - снять все заявки на рынке FORTS,
		///     «KILL_RTS_T4_LONG_LIMIT» - удалить лимит открытых позиций на спот-рынке RTS Standard,
		///     «KILL_RTS_T4_SHORT_LIMIT» - удалить лимит открытых позиций клиента по спот-активу на рынке RTS Standard,
		///     «MOVE_ORDERS» - переставить заявки на рынке FORTS,
		///     «NEW_QUOTE» - новая безадресная заявка,
		///     «KILL_QUOTE» - снять безадресную заявку,
		///     «NEW_REPORT» - новая  заявка-отчет о подтверждении транзакций в режимах РПС и РЕПО,
		///     «SET_FUT_LIMIT» - новое ограничение по фьючерсному счету
		/// </summary>
		public string ACTION { get; set; }

		/// <summary>
		///     Идентификатор участника торгов (код фирмы)
		/// </summary>
		public string FIRM_ID { get; set; }

		/// <summary>
		///     Номер счета Трейдера, обязательный параметр.
		///     Параметр чувствителен к верхнему/нижнему регистру символов.
		/// </summary>
		public string ACCOUNT { get; set; }

		/// <summary>
		///     20-ти символьное составное поле, может содержать код клиента и текстовый комментарий с тем же разделителем, что и
		///     при вводе заявки вручную.
		///     Параметр используется только для групповых транзакций.
		///     Необязательный параметр
		/// </summary>
		public string CLIENT_CODE { get; set; }

		/// <summary>
		///     Тип заявки, необязательный параметр.
		///     Значения: «L» – лимитированная (по умолчанию), «M» – рыночная
		/// </summary>
		public string TYPE { get; set; }

		/// <summary>
		///     Признак того, является ли заявка заявкой Маркет-Мейкера.
		///     Возможные значения: «YES» или «NO».
		///     Значение по умолчанию (если параметр отсутствует): «NO»
		/// </summary>
		public string MARKET_MAKER_ORDER { get; set; }

		/// <summary>
		///     Направление заявки, обязательный параметр.
		///     Значения: «S» – продать, «B» – купить
		/// </summary>
		public string OPERATION { get; set; }

		/// <summary>
		///     Условие исполнения заявки, необязательный параметр.
		///     Возможные значения:
		///     «PUT_IN_QUEUE» – поставить в очередь (по умолчанию),
		///     «FILL_OR_KILL» – немедленно или отклонить,
		///     «KILL_BALANCE» – снять остаток
		/// </summary>
		public string EXECUTION_CONDITION { get; set; }

		/// <summary>
		///     Количество лотов в заявке, обязательный параметр
		/// </summary>
		public string QUANTITY { get; set; }

		/// <summary>
		///     Цена заявки, за единицу инструмента.
		///     Обязательный параметр.
		///     При выставлении рыночной заявки (TYPE=M) на Срочном рынке FORTS необходимо указывать
		///     значение цены – укажите наихудшую (минимально или максимально возможную – в зависимости от направленности),
		///     заявка все равно будет исполнена по рыночной цене.
		///     Для других рынков при выставлении рыночной заявки укажите price= 0.
		/// </summary>
		public string PRICE { get; set; }

		/// <summary>
		///     Стоп-цена, за единицу инструмента.
		///     Используется только при «ACTION» = «NEW_STOP_ORDER»
		/// </summary>
		public string STOPPRICE { get; set; }

		/// <summary>
		///     Тип стоп-заявки. Возможные значения:
		///     «SIMPLE_STOP_ORDER» – стоп-лимит,
		///     «CONDITION_PRICE_BY_OTHER_SEC» – с условием по другой бумаге,
		///     «WITH_LINKED_LIMIT_ORDER» – со связанной заявкой,
		///     «TAKE_PROFIT_STOP_ORDER» – тэйк-профит,
		///     «TAKE_PROFIT_AND_STOP_LIMIT_ORDER» - тэйк-профит и стоп-лимит,
		///     «ACTIVATED_BY_ORDER_SIMPLE_STOP_ORDER» – стоп-лимит по исполнению заявки,
		///     «ACTIVATED_BY_ORDER_TAKE_PROFIT_STOP_ORDER» – тэйк-профит по исполнению заявки,
		///     «ACTIVATED_BY_ORDER_TAKE_PROFIT_AND_STOP_LIMIT_ORDER» - тэйк-профит и стоп-лимит по исполнению заявки.
		///     Если параметр пропущен, то считается, что заявка имеет тип «стоп-лимит»
		/// </summary>
		public string STOP_ORDER_KIND { get; set; }

		/// <summary>
		///     Класс инструмента условия.
		///     Используется только при «STOP_ORDER_KIND» = «CONDITION_PRICE_BY_OTHER_SEC».
		/// </summary>
		public string STOPPRICE_CLASSCODE { get; set; }

		/// <summary>
		///     Код инструмента условия.
		///     Используется только при «STOP_ORDER_KIND» = «CONDITION_PRICE_BY_OTHER_SEC»
		/// </summary>
		public string STOPPRICE_SECCODE { get; set; }

		/// <summary>
		///     Направление предельного изменения стоп-цены.
		///     Используется только при «STOP_ORDER_KIND» = «CONDITION_PRICE_BY_OTHER_SEC».
		///     Возможные значения: <= или >=
		/// </summary>
		public string STOPPRICE_CONDITION { get; set; }

		/// <summary>
		///     Цена связанной лимитированной заявки.
		///     Используется только при «STOP_ORDER_KIND» = «WITH_LINKED_LIMIT_ORDER»
		/// </summary>
		public string LINKED_ORDER_PRICE { get; set; }

		/// <summary>
		///     Срок действия стоп-заявки. Возможные значения:
		///     «GTC» – до отмены,
		///     «TODAY» - до окончания текущей торговой сессии,
		///     Дата в формате «ГГММДД».
		/// </summary>
		public string EXPIRY_DATE { get; set; }

		/// <summary>
		///     Цена условия «стоп-лимит» для заявки типа «Тэйк-профит и стоп-лимит»
		/// </summary>
		public string STOPPRICE2 { get; set; }

		/// <summary>
		///     Признак исполнения заявки по рыночной цене при наступлении условия «стоп-лимит».
		///     Значения «YES» или «NO».
		///     Параметр заявок типа «Тэйк-профит и стоп-лимит»
		/// </summary>
		public string MARKET_STOP_LIMIT { get; set; }

		/// <summary>
		///     Признак исполнения заявки по рыночной цене при наступлении условия «тэйк-профит».
		///     Значения «YES» или «NO».
		///     Параметр заявок типа «Тэйк-профит и стоп-лимит»
		/// </summary>
		public string MARKET_TAKE_PROFIT { get; set; }

		/// <summary>
		///     Признак действия заявки типа «Тэйк-профит и стоп-лимит» в течение определенного интервала времени.
		///     Значения «YES» или «NO»
		/// </summary>
		public string IS_ACTIVE_IN_TIME { get; set; }

		/// <summary>
		///     Время начала действия заявки типа «Тэйк-профит и стоп-лимит» в формате «ЧЧММСС»
		/// </summary>
		public string ACTIVE_FROM_TIME { get; set; }

		/// <summary>
		///     Время окончания действия заявки типа «Тэйк-профит и стоп-лимит» в формате «ЧЧММСС»
		/// </summary>
		public string ACTIVE_TO_TIME { get; set; }

		/// <summary>
		///     Номер заявки, снимаемой из торговой системы.
		///     Применяется при «ACTION» = «KILL_ORDER» или «ACTION» = «KILL_NEG_DEAL» или «ACTION» = «KILL_QUOTE»
		/// </summary>
		public string ORDER_KEY { get; set; }

		/// <summary>
		///     Номер стоп-заявки, снимаемой из торговой системы.
		///     Применяется только при «ACTION» = «KILL_STOP_ORDER»
		/// </summary>
		public string STOP_ORDER_KEY { get; set; }

		/// <summary>
		///     Уникальный идентификационный номер заявки, значение от 1 до 2 294 967 294
		/// </summary>
		public string TRANS_ID { get; set; }

		/// <summary>
		///     Текстовый комментарий, указанный в заявке.
		///     Используется при снятии группы заявок
		/// </summary>
		public string COMMENT { get; set; }

		/// <summary>
		///     Признак снятия стоп-заявки при частичном исполнении связанной лимитированной заявки.
		///     Используется только при «STOP_ORDER_KIND» = «WITH_LINKED_LIMIT_ORDER».
		///     Возможные значения: «YES» или «NO»
		/// </summary>
		public string KILL_IF_LINKED_ORDER_PARTLY_FILLED { get; set; }

		/// <summary>
		///     Величина отступа от максимума (минимума) цены последней сделки.
		///     Используется при «STOP_ORDER_KIND» = «TAKE_PROFIT_STOP_ORDER» или
		///     «ACTIVATED_BY_ORDER_TAKE_PROFIT_STOP_ORDER»
		/// </summary>
		public string OFFSET { get; set; }

		/// <summary>
		///     Единицы измерения отступа. Возможные значения:
		///     «PERCENTS» – в процентах (шаг изменения – одна сотая процента),
		///     «PRICE_UNITS» – в параметрах цены (шаг изменения равен шагу цены по данному инструменту).
		///     Используется при «STOP_ORDER_KIND» = «TAKE_PROFIT_STOP_ORDER» или «ACTIVATED_BY_ORDER_TAKE_PROFIT_STOP_ORDER»
		/// </summary>
		public string OFFSET_UNITS { get; set; }

		/// <summary>
		///     Величина защитного спрэда. Используется при «STOP_ORDER_KIND» = «TAKE_PROFIT_STOP_ORDER»
		///     или ACTIVATED_BY_ORDER_TAKE_PROFIT_STOP_ORDER»
		/// </summary>
		public string SPREAD { get; set; }

		/// <summary>
		///     Единицы измерения защитного спрэда. Возможные значения:
		///     «PERCENTS» – в процентах (шаг изменения – одна сотая процента),
		///     «PRICE_UNITS» – в параметрах цены (шаг изменения равен шагу цены по данному инструменту).
		///     Используется при «STOP_ORDER_KIND» = «TAKE_PROFIT_STOP_ORDER» или «ACTIVATED_BY_ORDER_TAKE_PROFIT_STOP_ORDER»
		/// </summary>
		public string SPREAD_UNITS { get; set; }

		/// <summary>
		///     Регистрационный номер заявки-условия.
		///     Используется при «STOP_ORDER_KIND» = «ACTIVATED_BY_ORDER_SIMPLE_STOP_ORDER» или
		///     «ACTIVATED_BY_ORDER_TAKE_PROFIT_STOP_ORDER»
		/// </summary>
		public string BASE_ORDER_KEY { get; set; }

		/// <summary>
		///     Признак использования в качестве объема заявки «по исполнению» исполненного
		///     количества бумаг заявки-условия. Возможные значения: «YES» или «NO».
		///     используется при «STOP_ORDER_KIND» = «ACTIVATED_BY_ORDER_SIMPLE_STOP_ORDER» или
		///     «ACTIVATED_BY_ORDER_TAKE_PROFIT_STOP_ORDER»
		/// </summary>
		public string USE_BASE_ORDER_BALANCE { get; set; }

		/// <summary>
		///     Признак активации заявки «по исполнению» при частичном исполнении заявки-условия.
		///     Возможные значения: «YES» или «NO». Используется при «STOP_ORDER_KIND» = «ACTIVATED_BY_ORDER_SIMPLE_STOP_ORDER» или
		///     «ACTIVATED_BY_ORDER_TAKE_PROFIT_STOP_ORDER»
		/// </summary>
		public string ACTIVATE_IF_BASE_ORDER_PARTLY_FILLED { get; set; }

		/// <summary>
		///     Идентификатор базового контракта для фьючерсов или опционов.
		///     Обязательный параметр снятия заявок на рынке FORTS
		/// </summary>
		public string BASE_CONTRACT { get; set; }

		/// <summary>
		///     Режим перестановки заявок на рынке FORTS. Параметр операции «ACTION» = «MOVE_ORDERS» Возможные значения:
		///     «0» – оставить количество в заявках без изменения,
		///     «1» – изменить количество в заявках на новые,
		///     «2» – при несовпадении новых количеств с текущим хотя бы в одной заявке, обе заявки снимаются
		///     Перестановка заявок на рынке FORTS выполняется по следующим правилам:
		///     Если MODE=0, то заявки с номерами, указанными после ключей FIRST_ORDER_NUMBER и SECOND_ORDER_NUMBER, снимаются.
		///     В торговую систему отправляются две новые заявки, при этом изменяется только цена заявок, количество остается
		///     прежним;
		///     Если MODE=1, то заявки с номерами, указанными после ключей FIRST_ORDER_NUMBER и SECOND_ORDER_NUMBER, снимаются.
		///     В торговую систему отправляются две новые заявки, при этом изменится как цена заявки, так и количество;
		///     Если MODE=2,  то заявки с номерами, указанными после ключей FIRST_ORDER_NUMBER и SECOND_ORDER_NUMBER, снимаются.
		///     Если количество бумаг в каждой из снятых заявок совпадает со значениями, указанными после FIRST_ORDER_NEW_QUANTITY
		///     и SECOND_ORDER_NEW_QUANTITY, то в торговую систему отправляются две новые заявки с соответствующими параметрами.
		/// </summary>
		public string MODE { get; set; }

		/// <summary>
		///     Номер первой заявки
		/// </summary>
		public string FIRST_ORDER_NUMBER { get; set; }

		/// <summary>
		///     Количество в первой заявке
		/// </summary>
		public string FIRST_ORDER_NEW_QUANTITY { get; set; }

		/// <summary>
		///     Цена в первой заявке
		/// </summary>
		public string FIRST_ORDER_NEW_PRICE { get; set; }

		/// <summary>
		///     Номер второй заявки
		/// </summary>
		public string SECOND_ORDER_NUMBER { get; set; }

		/// <summary>
		///     Цена во второй заявке
		/// </summary>
		public string SECOND_ORDER_NEW_QUANTITY { get; set; }

		/// <summary>
		///     Количество во второй заявке
		/// </summary>
		public string SECOND_ORDER_NEW_PRICE { get; set; }

		/// <summary>
		///     Признак снятия активных заявок по данному инструменту.
		///     Используется только при «ACTION» = «NEW_QUOTE». Возможные значения: «YES» или «NO»
		/// </summary>
		public string KILL_ACTIVE_ORDERS { get; set; }

		/// <summary>
		///     Направление операции в сделке, подтверждаемой отчетом
		/// </summary>
		public string NEG_TRADE_OPERATION { get; set; }

		/// <summary>
		///     Номер подтверждаемой отчетом сделки для исполнения
		/// </summary>
		public string NEG_TRADE_NUMBER { get; set; }

		/// <summary>
		///     Лимит открытых позиций, при «Тип лимита» = «Ден.средства» или «Всего»
		/// </summary>
		public string VOLUMEMN { get; set; }

		/// <summary>
		///     Лимит открытых позиций, при «Тип лимита» = «Залоговые ден.средства»
		/// </summary>
		public string VOLUMEPL { get; set; }

		/// <summary>
		///     Признак проверки попадания цены заявки в диапазон допустимых цен.
		///     Параметр Срочного рынка FORTS. Необязательный параметр транзакций установки
		///     новых заявок по классам «Опционы ФОРТС» и «РПС: Опционы ФОРТС».
		///     Возможные значения: «YES» - выполнять проверку, «NO» - не выполнять
		/// </summary>
		public string CHECK_LIMITS { get; set; }

		/// <summary>
		///     Ссылка, которая связывает две сделки РЕПО или РПС. Сделка может быть заключена только между контрагентами,
		///     указавшими одинаковое значение этого параметра в своих заявках.
		///     Параметр представляет собой набор произвольный набор количеством до 10 символов (допускаются цифры и буквы).
		///     Необязательный параметр
		/// </summary>
		public string MATCHREF { get; set; }

		/// <summary>
		///     Режим корректировки ограничения по фьючерсным счетам. Возможные значения:
		///     «Y» - включен, установкой лимита изменяется действующее значение,
		///     «N» - выключен (по умолчанию), установкой лимита задается новое значение
		/// </summary>
		public string CORRECTION { get; set; }

		/// <summary>
		///     Объем сделки РЕПО-М в рублях
		/// </summary>
		public string REPOVALUE { get; set; }

		/// <summary>
		///     Начальное значение дисконта в заявке на сделку РЕПО-М
		/// </summary>
		public string START_DISCOUNT { get; set; }

		/// <summary>
		///     Нижнее предельное значение дисконта в заявке на сделку РЕПО-М
		/// </summary>
		public string LOWER_DISCOUNT { get; set; }

		/// <summary>
		///     Верхнее предельное значение дисконта в заявке на сделку РЕПО-М
		/// </summary>
		public string UPPER_DISCOUNT { get; set; }

		/// <summary>
		///     Код организации – партнера по внебиржевой сделке.
		///     Применяется при «ACTION» = «NEW_NEG_DEAL», «ACTION» = «NEW_REPO_NEG_DEAL» или «ACTION» = «NEW_EXT_REPO_NEG_DEAL»
		/// </summary>
		public string PARTNER { get; set; }

		/// <summary>
		///     Код расчетов при исполнении внебиржевых заявок
		/// </summary>
		public string SETTLE_CODE { get; set; }

		/// <summary>
		///     Цена второй части РЕПО
		/// </summary>
		public string PRICE2 { get; set; }

		/// <summary>
		///     Срок РЕПО. Параметр сделок РЕПО-М
		/// </summary>
		public string REPOTERM { get; set; }

		/// <summary>
		///     Ставка РЕПО, в процентах
		/// </summary>
		public string REPORATE { get; set; }

		/// <summary>
		///     Признак блокировки бумаг на время операции РЕПО («YES», «NO»)
		/// </summary>
		public string BLOCK_SECURITIES { get; set; }

		/// <summary>
		///     Ставка фиксированного возмещения, выплачиваемого в случае неисполнения второй части РЕПО, в процентах
		/// </summary>
		public string REFUNDRATE { get; set; }

		/// <summary>
		///     Признак крупной сделки (YES/NO).
		///     Параметр внебиржевой сделки
		/// </summary>
		public string LARGE_TRADE { get; set; }

		/// <summary>
		///     Код валюты расчетов по внебиржевой сделки, например «SUR» – рубли РФ, «USD» – доллары США.
		///     Параметр внебиржевой сделки
		/// </summary>
		public string CURR_CODE { get; set; }

		/// <summary>
		///     Лицо, от имени которого и за чей счет регистрируется сделка (параметр внебиржевой сделки). Возможные значения:
		///     «OWNOWN» – от своего имени, за свой счет,
		///     «OWNCLI» - от своего имени, за счет клиента,
		///     «OWNDUP» - от своего имени, за счет доверительного управления,
		///     «CLICLI» - от имени клиента, за счет клиента
		/// </summary>
		public string FOR_ACCOUNT { get; set; }

		/// <summary>
		///     Дата исполнения внебиржевой сделки
		/// </summary>
		public string SETTLE_DATE { get; set; }

		/// <summary>
		///     Коэффициент ликвидности
		/// </summary>
		public string KFL { get; set; }

		/// <summary>
		///     Коэффициент клиентского гарантийного обеспечения
		/// </summary>
		public string KGO { get; set; }

		/// <summary>
		///     Параметр, который определяет, будет ли загружаться величина КГО при загрузке лимитов из файла:
		///     при USE_KGO=Y – величина КГО загружает.
		///     при USE_KGO=N – величина КГО не загружается
		///     При установке лимита на Срочном рынке ММВБ с принудительным понижением (см. Создание лимита) требуется указать
		///     USE_KGO= Y
		/// </summary>
		public string USE_KGO { get; set; }
	}
}
