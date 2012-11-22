using BusinessLogic;

namespace Domain
{
    /// <summary>
    /// �������� � �������������� ��������� � ��������
    /// </summary>
    public class Operations : IOperations
    {
        /// <summary>
        /// ��� �������� (��� ������)
        /// </summary>
        public string Name { get; set; } 
        /// <summary>
        /// ��������
        /// </summary>
        public string Value { get; set; }  
        /// <summary>
        /// ���������� ���������
        /// </summary>
        public int Operands { get; set; }  
        /// <summary>
        /// ���������
        /// </summary>
        public int Priority { get; set; }  
        /// <summary>
        /// ��� ������, ��� ��������� ��������������� �����
        /// </summary>
        public string Placement { get; set; }  
        /// <summary>
        /// ������ ��� ����
        /// </summary>
        public string Type { get; set; }  
    }
}